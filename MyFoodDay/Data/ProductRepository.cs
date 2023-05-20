using LiteDB;
using MyFoodDay.DataContext;
using MyFoodDay.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFoodDay.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly LiteDatabase context = new LiteDatabase(@"Filename=E:\Projects\MyFoodDay\MyFoodDay\ProductDatabase.db;connection=shared");
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
            var issues = context.GetCollection<Product>();

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

            issues.Insert(newProduct);
        }
    }
}
