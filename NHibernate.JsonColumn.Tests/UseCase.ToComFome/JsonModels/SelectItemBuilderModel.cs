using BCL;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels
{
    public class SelectItemBuilderModel
    {
        public string[] Key { get; set; }
        public Either<string, string[]>? CssClass { get; set; }
        public Either<string, string[]>? Display { get; set; }
        public Either<string, decimal, decimal[]>? Price { get; set; }
        public Either<string, bool, bool[]>? IsVisible { get; set; }
    }
}