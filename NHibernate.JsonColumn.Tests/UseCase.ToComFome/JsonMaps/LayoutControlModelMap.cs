using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class LayoutControlModelMap : JsonMap<LayoutControlModel>
    {
        public LayoutControlModelMap()
        {
            this.DiscriminateSubClassesOnField("layout");
            this.Map(x => x.Fields, "fields");
        }
    }
}