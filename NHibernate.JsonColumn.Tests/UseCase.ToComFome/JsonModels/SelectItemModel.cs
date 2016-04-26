using System;
using JetBrains.Annotations;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels
{
    public class SelectItemModel
    {
        public SelectItemModel()
        {
        }

        public SelectItemModel([NotNull] string display, decimal price = 0.00m, string jsonProps = null)
        {
            if (String.IsNullOrEmpty(display))
                throw new ArgumentException("Argument is null or empty", nameof(display));

            this.Display = display;
            this.Price = price;
            this.JsonProps = jsonProps;
        }

        public string Display { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets additional custom properties stored as a JSON string.
        /// </summary>
        public string JsonProps { get; set; }
    }
}