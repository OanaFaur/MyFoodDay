using LiteDB;
using System;

namespace MyFoodDay.Models
{
    public class ConsumedProduct
    {
        [BsonId]
        public int ConsumedProductId { get; set; }
        public string ProductName { get; set; }

        public double QuantityConsumed { get; set; }

        public double CaloriesConsumed { get; set; }

        public double ProteinsConsumed { get; set; }

        public DateTime Date { get; set; }

        public ConsumedProduct(string productName, double quantityConsumed, double caloriesConsumed, double proteindConsumed, DateTime date)
        {
            ProductName = productName;
            QuantityConsumed = quantityConsumed;
            CaloriesConsumed = caloriesConsumed;
            ProteinsConsumed = proteindConsumed;
            //DayTime = dayTime;
            Date = date;
        }
        public ConsumedProduct()
        {

        }
    }
}
