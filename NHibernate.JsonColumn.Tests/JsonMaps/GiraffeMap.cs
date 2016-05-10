using FluentJsonNet;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.JsonMaps
{
    public class GiraffeMap : JsonSubclassMap<Giraffe>
    {
        public GiraffeMap()
        {
            this.Map(x => x.Height, "Height");
        }
    }
}