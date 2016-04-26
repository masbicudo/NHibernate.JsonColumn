using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class CheckBoxModelMap : JsonSubclassMap<CheckBoxModel>
    {
        public CheckBoxModelMap()
        {
            this.DiscriminatorValue("CheckBox");
        }
    }
}
