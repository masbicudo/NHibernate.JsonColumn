using FluentNHibernate.Mapping;
using NHibernate.JsonColumn.Tests.Code;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.Models;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.NHMaps
{
    public class ProductFluentNHMap : ClassMap<ProductModel>
    {
        public ProductFluentNHMap()
        {
            this.Table("tcf_products");

            this.Id(x => x.Id)
                .GeneratedBy.Native();

            this.Map(x => x.Key)
              .Not.Nullable();

            this.Map(x => x.Title)
              .Not.Nullable();

            this.Map(x => x.Description)
              .Nullable();

            this.Map(x => x.Photo)
              .Not.Nullable();

            this.Map(x => x.Price);

            this.MapJson(x => x.Customizer)
                .Not.Nullable();
        }
    }
}
