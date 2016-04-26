using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class CustomEnumEditorControlModelMap : JsonMap<CustomEnumEditorControlModel>
    {
        public CustomEnumEditorControlModelMap()
        {
            this.DiscriminateSubClassesOnField("editor");
            this.Map(x => x.Default, "default");
            this.Map(x => x.ItemBuilder, "itemBuilder");
            this.Map(x => x.Items, "items");
            this.Map(x => x.Key, "key");
        }
    }
}