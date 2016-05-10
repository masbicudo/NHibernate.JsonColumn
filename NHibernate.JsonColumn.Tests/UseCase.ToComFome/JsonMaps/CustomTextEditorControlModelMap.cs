using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class CustomTextEditorControlModelMap : JsonSubclassMap<CustomTextEditorControlModel>
    {
        public CustomTextEditorControlModelMap()
        {
            this.DiscriminateSubClassesOnField("editor");
            this.Map(x => x.Default, "default");
            this.Map(x => x.Key, "key");
        }
    }
}