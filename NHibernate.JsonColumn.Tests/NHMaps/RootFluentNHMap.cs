using FluentNHibernate.Mapping;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.NHMaps
{
    /// <summary>
    /// Maps the <see cref="Root"/> type.
    /// This is the Fluent-NHibernate code mapping style.
    /// See <see cref="RootNHMap"/> for the same thing using pure NHibernate.
    /// </summary>
    public class RootFluentNHMap : ClassMap<Root>
    {
        public RootFluentNHMap()
        {
            this.Id(x => x.Id).GeneratedBy.Identity();

            this.Map(x => x.Vehicle)
                .Length(8096)
                .CustomType<JsonMappableType<Vehicle>>();

            this.Map(x => x.Animal)
                .Length(8096)
                .CustomType<JsonMappableType<Animal>>();

            this.Map(x => x.Furniture)
                .Length(8096)
                .CustomType<JsonMappableType<Furniture>>();
        }
    }
}