using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class SwitchButtonModelMap : JsonSubclassMap<SwitchButtonModel>
    {
        public SwitchButtonModelMap()
        {
            this.DiscriminatorValue("SwitchButton");
            this.Map(x => x.Display, "display");
        }
    }
}