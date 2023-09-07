using LiteDB;
using MyFoodDay.DataContext;
using MyFoodDay.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFoodDay.Data
{
    public class ProductRepository : IProductRepository
    {
        private MyFoodContext foodContext = new MyFoodContext();
        public ProductRepository()
        {

        }

        public Product FindByName(string name)
        {
            return GetProducts.FirstOrDefault(p => p.ProductName == name);
        }

        public List<Product> GetProducts
        {
            get
            {
                return foodContext.Products.ToList();
            }
        }

        public Product FindById(string name)
        {
            return GetProducts.Where(p => p.ProductName == name).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            Product newProduct;

            newProduct = new Product
            {
                ProductName = product.ProductName,
                Calories = product.Calories,
                Quantity = product.Quantity,
                Proteins = product.Proteins,
                Fats = product.Fats,
                MeasurementType = product.MeasurementType
            };

            foodContext.Add(newProduct);
            foodContext.SaveChanges();
        }
    }
}
