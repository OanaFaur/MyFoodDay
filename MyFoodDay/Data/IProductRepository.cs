using MyFoodDay.Models;
using System.Collections.Generic;

namespace MyFoodDay.Data
{
    public interface IProductRepository
    {
        List<Product> GetProducts { get; }

        Product FindByName(string name);

        void AddProduct(Product product);
    }
}
