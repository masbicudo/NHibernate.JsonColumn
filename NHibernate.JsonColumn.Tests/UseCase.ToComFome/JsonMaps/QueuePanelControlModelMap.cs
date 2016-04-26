using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class QueuePanelControlModelMap : JsonSubclassMap<QueuePanelControlModel>
    {
        public QueuePanelControlModelMap()
        {
            this.DiscriminatorValue("QueuePanelControl");
        }
    }
}