using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.Models
{
    public class ProductModel
    {
        public virtual int Id { get; set; }
        public virtual string Key { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Photo { get; set; }
        public virtual decimal Price { get; set; }
        public virtual LayoutControlModel Customizer { get; set; }
    }
}