using LiteDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFoodDay.DataContext;
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
        private MyFoodContext foodContext = new MyFoodContext();

        public void AddConsumedProduct(EatenProduct consumedProduct)
        {
            foodContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.EatenProducts ON;");
            foodContext.EatenProducts.Add(consumedProduct);
            foodContext.SaveChanges();
            foodContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.EatenProducts OFF;");
        }

        public List<EatenProduct> GetConsumedProducts
        {
            get
            {
                return foodContext.EatenProducts.ToList();
            }
        }

        public IEnumerable<EatenProduct> GetDailyConsumedProducts(DateTime date, string userId)
        {
            return GetEatenProductByUser(userId).Where(x => x.Date == date);
        }

        public IEnumerable<EatenProduct> GetEatenProductByUser(string userId)
        {
            return GetConsumedProducts.Where(x => x.UserId ==userId);
        }
    }
}
