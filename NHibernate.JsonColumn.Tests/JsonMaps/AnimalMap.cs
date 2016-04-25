using FluentJsonNet;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.JsonMaps
{
    public class AnimalMap : JsonMap<Animal>
    {
        public AnimalMap()
        {
            this.DiscriminateSubClassesOnField("class");
            this.Map(x => x.Speed, "speed");
        }
    }
}
