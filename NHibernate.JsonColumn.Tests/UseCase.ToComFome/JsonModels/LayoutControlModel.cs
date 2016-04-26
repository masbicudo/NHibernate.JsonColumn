using System.Collections.Generic;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels
{
    public abstract class LayoutControlModel : ControlModel
    {
        //public string Layout { get; set; }
        public ICollection<ControlModel> Fields { get; set; }
    }
}