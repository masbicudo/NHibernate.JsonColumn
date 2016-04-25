using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace NHibernate.JsonColumn
{
    public class JsonMappableType<T> : IUserType
    {
        // http://blog.denouter.net/2015/03/json-serialized-object-in-nhibernate.html

        public object Assemble(object cached, object owner)
        {
            //Used for caching, as our object is immutable we can just return it as is
            return cached;
        }

        public object DeepCopy(object value)
        {
            //We deep copy the Translation by creating a new instance with the same contents
            if (value == null)
                return null;
            if (!(value is T))
                throw new Exception($"Invalid type of value in property. It should be `{nameof(T)}`.");
            var result = FromJson(ToJson((T)value));
            return result;
        }

        public object Disassemble(object value)
        {
            //Used for caching, as our object is immutable we can just return it as is
            return value;
        }

        public new bool Equals(object x, object y)
        {
            //Use JSON-query-string to see if their equal 
            // on value so we use this implementation
            if (x == null || y == null)
                return false;
            if (x is T || y is T)
                return ToJson((T)x) == ToJson((T)y);
            return false;
        }

        public int GetHashCode(object x)
        {
            if (x is T)
                return ToJson((T)x).GetHashCode();
            return (x?.GetHashCode() ?? 0) ^ 1695687702;
        }

        public bool IsMutable => false;

        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            //We get the string from the database using the NullSafeGet used to get strings 
            string jsonString = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
            //And save it in the T object. This would be the place to make sure that your string 
            //is valid for use with the T class
            return FromJson(jsonString);
        }

        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            //Set the value using the NullSafeSet implementation for string from NHibernateUtil
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
            value = ToJson((T)value);
            NHibernateUtil.String.NullSafeSet(cmd, value, index);
        }

        public object Replace(object original, object target, object owner)
        {
            //As our object is immutable we can just return the original
            return original;
        }

        public System.Type ReturnedType => typeof(T);

        public SqlType[] SqlTypes
        {
            get
            {
                //We store our translation in a single column in the database that can contain a string
                SqlType[] types = new SqlType[1];
                types[0] = new SqlType(System.Data.DbType.String);
                return types;
            }
        }

        private static JsonSerializerSettings JsonSetting => new JsonSerializerSettings
        {
            ContractResolver = new OrderedContractResolver(JsonConvert.DefaultSettings?.Invoke()?.ContractResolver),
            Formatting = Formatting.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        public static T FromJson(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);
            return JsonConvert.DeserializeObject<T>(jsonString, JsonSetting);
        }

        public static string ToJson(T obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSetting);
        }

        /// <summary>
        /// Order the JSON-properties to create a simple equals case for JsonMappableType.Equals
        /// </summary>
        private class OrderedContractResolver : DefaultContractResolver
        {
            public OrderedContractResolver(IContractResolver otherContractResolver)
            {
                this.OtherContractResolver = otherContractResolver;
            }

            [CanBeNull]
            public IContractResolver OtherContractResolver { get; set; }

            //protected override JsonContract CreateContract(System.Type objectType)
            //{
            //    var oldContract = this.OtherContractResolver?.ResolveContract(objectType);
            //    var newContract = base.CreateContract(objectType);
            //
            //    if (oldContract == null)
            //        return newContract;
            //
            //    if (newContract is JsonObjectContract)
            //    {
            //        var oldObjectContract = oldContract as JsonObjectContract;
            //        if (oldObjectContract != null)
            //        {
            //            // TODO: we should merge both contracts here
            //            return newContract;
            //        }
            //    }
            //
            //    if (newContract is JsonDynamicContract)
            //    {
            //        var oldDynamicContract = oldContract as JsonDynamicContract;
            //        if (oldDynamicContract != null)
            //        {
            //            // TODO: we should merge both contracts here
            //            return newContract;
            //        }
            //    }
            //
            //    if (oldContract.GetType() == newContract.GetType())
            //        return oldContract;
            //
            //    return newContract;
            //}

            protected override JsonArrayContract CreateArrayContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonArrayContract ?? base.CreateArrayContract(objectType);
            }

            protected override JsonDictionaryContract CreateDictionaryContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonDictionaryContract ?? base.CreateDictionaryContract(objectType);
            }

            protected override JsonDynamicContract CreateDynamicContract(System.Type objectType)
            {
                var oldContract = this.OtherContractResolver?.ResolveContract(objectType) as JsonObjectContract;
                var newContract = base.CreateDynamicContract(objectType);
                if (oldContract != null)
                {
                    // TODO: we should merge both contracts here
                }
                return newContract;
            }

            protected override JsonISerializableContract CreateISerializableContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonISerializableContract ?? base.CreateISerializableContract(objectType);
            }

            protected override JsonLinqContract CreateLinqContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonLinqContract ?? base.CreateLinqContract(objectType);
            }

            protected override JsonObjectContract CreateObjectContract(System.Type objectType)
            {
                var oldContract = this.OtherContractResolver?.ResolveContract(objectType) as JsonObjectContract;
                var newContract = base.CreateObjectContract(objectType);
                if (oldContract != null)
                {
                    // TODO: we should merge both contracts here
                }
                return newContract;
            }

            protected override JsonPrimitiveContract CreatePrimitiveContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonPrimitiveContract ?? base.CreatePrimitiveContract(objectType);
            }

            protected override JsonStringContract CreateStringContract(System.Type objectType)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(objectType);
                return otherContract as JsonStringContract ?? base.CreateStringContract(objectType);
            }

            protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
            {
                var otherContract = this.OtherContractResolver?.ResolveContract(type);

                dynamic jsonObjContract = otherContract;
                if (jsonObjContract != null)
                    return ((JsonPropertyCollection)jsonObjContract.Properties).OrderBy(p => p.PropertyName).ToList();

                return base.CreateProperties(type, memberSerialization).OrderBy(p => p.PropertyName).ToList();
            }
        }
    }
}
