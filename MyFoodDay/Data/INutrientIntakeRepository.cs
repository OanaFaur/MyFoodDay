using Microsoft.AspNetCore.Identity;
using MyFoodDay.Models;
using System;
using System.Collections.Generic;

namespace MyFoodDay.Data
{
    public interface INutrientIntakeRepository
    {
        void AddConsumedProduct(EatenProduct consumedProduct);
        List<EatenProduct> GetConsumedProducts { get; }

        IEnumerable<EatenProduct> GetDailyConsumedProducts(DateTime date, string email);
    }
}
