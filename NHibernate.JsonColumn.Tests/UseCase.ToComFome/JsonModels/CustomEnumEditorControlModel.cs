using System.Collections.Generic;
using BCL;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels
{
    public abstract class CustomEnumEditorControlModel : ControlModel
    {
        public string Key { get; set; }
        //public string Editor { get; set; }
        public Either<ICollection<SelectItemModel>, IDictionary<string, SelectItemModel>> Items { get; set; }
        public SelectItemBuilderModel ItemBuilder { get; set; }
        public string Default { get; set; }
    }
}