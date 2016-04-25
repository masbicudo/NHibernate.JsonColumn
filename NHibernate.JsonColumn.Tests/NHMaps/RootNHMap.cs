using NHibernate.JsonColumn.Tests.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.JsonColumn.Tests.NHMaps
{
    /// <summary>
    /// Maps the <see cref="Root"/> type.
    /// This is the built-in NHibernate code mapping style.
    /// See <see cref="RootFluentNHMap"/> for the same thing using Fluent-NHibernate.
    /// </summary>
    public class RootNHMap : ClassMapping<Root>
    {
        public RootNHMap()
        {
            this.Id(x => x.Id, m => m.Generator(new IdentityGeneratorDef()));

            this.Property(x => x.Vehicle,
                m =>
                {
                    m.Length(8096);
                    m.Type<JsonMappableType<Vehicle>>();
                });

            this.Property(x => x.Animal,
                m =>
                {
                    m.Length(8096);
                    m.Type<JsonMappableType<Animal>>();
                });

            this.Property(x => x.Furniture,
                m =>
                {
                    m.Length(8096);
                    m.Type<JsonMappableType<Furniture>>();
                });
        }
    }
}
