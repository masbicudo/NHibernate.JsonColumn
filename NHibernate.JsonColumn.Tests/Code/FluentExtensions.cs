using System;
using System.Linq.Expressions;
using FluentNHibernate.Mapping;

namespace NHibernate.JsonColumn.Tests.Code
{
    public static class FluentExtensions
    {
        /// <summary>
        /// Maps a property to be serialized to JSON when saving to the database,
        /// or deserialized from JSON when loading from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="mapBase"></param>
        /// <param name="memberExpression"></param>
        /// <returns></returns>
        public static PropertyPart MapJson<T, TProp>(this ClasslikeMapBase<T> mapBase, Expression<Func<T, TProp>> memberExpression)
        {
            var expr = Expression.Lambda<Func<T, object>>(
                Expression.Convert(memberExpression.Body, typeof(object)),
                memberExpression.Parameters);

            return mapBase.Map(expr)
                .Length(8096)
                .CustomType<JsonMappableType<TProp>>();
        }
    }
}