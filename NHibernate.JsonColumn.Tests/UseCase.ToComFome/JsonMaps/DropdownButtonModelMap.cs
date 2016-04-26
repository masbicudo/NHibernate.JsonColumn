using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class DropdownButtonModelMap : JsonSubclassMap<DropdownButtonModel>
    {
        public DropdownButtonModelMap()
        {
            this.DiscriminatorValue("DropdownButton");
        }
    }
}