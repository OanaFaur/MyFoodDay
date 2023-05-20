namespace MyFoodDay.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Quantity { get; set; }

        public string MeasurementType { get; set; }

        public double Calories { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public Product(int productId, string productName, double quantity, string measurementType, double calories, double proteins, double carbs)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            MeasurementType = measurementType;
            Calories = calories;
            Proteins = proteins;
            Fats = carbs;
        }

        public Product()
        {

        }
    }
}
