using FluentJsonNet;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.JsonMaps
{
    public class FelineMap : JsonSubclassMap<Feline>
    {
        public FelineMap()
        {
            this.Map(x => x.SightRange, "sight");
        }
    }
}
