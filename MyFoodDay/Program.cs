using MyFoodDay.Data;
using MyFoodDay.Models;
using System;

namespace MyFoodDay
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepo = new ProductRepository();

            Product product1 = new Product
            {
                ProductName = "Fibrobar",
                MeasurementType = "Piece",
                Calories = 200,
                Fats = 1.1,
                Proteins = 13,
                Quantity = 1
            };

            Product product2 = new Product
            {
                ProductName = "Egg",
                MeasurementType = "Large",
                Calories = 60,
                Fats = 5,
                Proteins = 6,
                Quantity = 1
            };

            Product product3 = new Product
            {
                ProductName = "Gorgonzola",
                MeasurementType = "g",
                Calories = 330,
                Fats = 5,
                Proteins = 19,
                Quantity = 100
            };

            productRepo.AddProduct(product1);
            productRepo.AddProduct(product2);
            productRepo.AddProduct(product3);
        }
    }
}
