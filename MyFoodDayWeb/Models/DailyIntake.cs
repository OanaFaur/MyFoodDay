using System;

namespace MyFoodDayWeb.Models
{
    public class DailyIntake
    {
        public double CalorieNumber { get; set; }

        public double ProteinNumber { get; set; }

        public double Fats { get; set; }

        public DateTime DateTime { get; set; }
    }
}
