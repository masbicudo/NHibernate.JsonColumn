using FluentJsonNet;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests.JsonMaps
{
    public class VehicleMap : JsonMap<Vehicle>.AndSubtypes
    {
        public VehicleMap()
        {
            this.DiscriminateSubClassesOnField("class");
            this.Map(x => x.Speed, "speed");
        }
    }
}
