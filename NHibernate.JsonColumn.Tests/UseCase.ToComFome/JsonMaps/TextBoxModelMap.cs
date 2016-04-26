using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class TextBoxModelMap : JsonSubclassMap<TextBoxModel>
    {
        public TextBoxModelMap()
        {
            this.DiscriminatorValue("TextBox");
        }
    }
}