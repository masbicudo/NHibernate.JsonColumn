using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class TextSwitchButtonModelMap : JsonSubclassMap<TextSwitchButtonModel>
    {
        public TextSwitchButtonModelMap()
        {
            this.DiscriminatorValue("TextSwitchButton");
        }
    }
}