using FluentJsonNet;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.JsonMaps
{
    public class LionMap : JsonSubclassMap<Lion>
    {
        public LionMap()
        {
            this.DiscriminatorValue("lion");
            this.Map(x => x.Strength, "strength");
        }
    }
}
