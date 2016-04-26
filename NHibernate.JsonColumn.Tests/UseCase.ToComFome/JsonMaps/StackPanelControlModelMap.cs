using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class StackPanelControlModelMap : JsonSubclassMap<StackPanelControlModel>
    {
        public StackPanelControlModelMap()
        {
            this.DiscriminatorValue("StackPanelControl");
        }
    }
}