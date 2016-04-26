using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class SlideSwitchModelMap : JsonSubclassMap<SlideSwitchModel>
    {
        public SlideSwitchModelMap()
        {
            this.DiscriminatorValue("SlideSwitch");
        }
    }
}