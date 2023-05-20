using MyFoodDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFoodDay.Data
{
    public class NutrientIntakeRepository : INutrientIntakeRepository
    {
        public void AddConsumedProduct(ConsumedProduct consumedProduct)
        {
            throw new NotImplementedException();
        }

        public List<ConsumedProduct> GetConsumedProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsumedProduct> GetDailyConsumedProducts(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
