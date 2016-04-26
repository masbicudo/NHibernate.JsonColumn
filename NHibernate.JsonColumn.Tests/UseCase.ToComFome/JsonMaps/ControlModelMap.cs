using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class ControlModelMap : JsonMap<ControlModel>
    {
        public ControlModelMap()
        {
            this.Map(x => x.CssClass, "cssClass");
            this.Map(x => x.Title, "title");
        }
    }
}