using MyFoodDay.Models;
using System;
using System.Collections.Generic;

namespace MyFoodDay.Data
{
    public interface INutrientIntakeRepository
    {
        void AddConsumedProduct(ConsumedProduct consumedProduct);
        List<ConsumedProduct> GetConsumedProducts();

        IEnumerable<ConsumedProduct> GetDailyConsumedProducts(DateTime date);
    }
}
