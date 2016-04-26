using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class SelectItemBuilderModelMap : JsonMap<SelectItemBuilderModel>
    {
        public SelectItemBuilderModelMap()
        {
            this.Map(x => x.CssClass, "cssClass");
            this.Map(x => x.Display, "display");
            this.Map(x => x.IsVisible, "isVisible");
            this.Map(x => x.Key, "key");
            this.Map(x => x.Price, "price");
        }
    }
}