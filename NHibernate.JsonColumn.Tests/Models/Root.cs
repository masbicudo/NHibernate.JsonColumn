namespace NHibernate.JsonColumn.Tests.Models
{
    public class Root
    {
        public virtual int Id { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Furniture Furniture { get; set; }
    }
}