using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.NHMaps
{
    public class ProductNHMap : ClassMapping<ProductModel>
    {
        public ProductNHMap()
        {
            this.Table("tcf_products");

            this.Id(x => x.Id, m => m.Generator(new IdentityGeneratorDef()));

            this.Property(x => x.Key,
                m =>
                {
                    m.NotNullable(true);
                });

            this.Property(x => x.Title,
                m =>
                {
                    m.NotNullable(true);
                });

            this.Property(x => x.Description,
                m =>
                {
                    m.NotNullable(false);
                });

            this.Property(x => x.Photo,
                m =>
                {
                    m.NotNullable(false);
                });

            this.Property(x => x.Price,
                m =>
                {
                });

            this.Property(x => x.Customizer,
                m =>
                {
                    m.Length(8096);
                    m.Type<JsonMappableType<LayoutControlModel>>();
                });
        }
    }
}
