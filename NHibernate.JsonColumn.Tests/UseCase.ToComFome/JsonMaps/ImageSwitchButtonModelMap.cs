using FluentJsonNet;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonMaps
{
    public class ImageSwitchButtonModelMap : JsonSubclassMap<ImageSwitchButtonModel>
    {
        public ImageSwitchButtonModelMap()
        {
            this.DiscriminatorValue("ImageSwitchButton");
        }
    }
}