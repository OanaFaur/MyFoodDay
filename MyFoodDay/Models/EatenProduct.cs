using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFoodDay.Models
{
    public class EatenProduct
    {
        [Key]
        public int ConsumedProductId { get; set; }

        public string ProductName { get; set; }

        public double QuantityConsumed { get; set; }

        public double CaloriesConsumed { get; set; }

        public double ProteinsConsumed { get; set; }

        public double FatsConsumed { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public EatenProduct()
        {

        }
    }
}
