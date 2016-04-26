using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class SelectItemModelMap : JsonMap<SelectItemModel>
    {
        public SelectItemModelMap()
        {
            this.Map(x => x.Display, "display");
            this.Map(x => x.JsonProps, "props");
            this.Map(x => x.Price, "price");
        }
    }
}