using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class ClassSwitchModelMap : JsonSubclassMap<ClassSwitchModel>
    {
        public ClassSwitchModelMap()
        {
            this.DiscriminatorValue("ClassSwitch");
        }
    }
}