using System.ComponentModel.DataAnnotations;

namespace MyFoodDay.Models
{
    public class UserAdditionalInfo
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        public string Email { get; set; }

        [Display(Name = "Daily calorie goal")]
        public double DailyCalorieGoal { get; set; }

        [Display(Name="Daily Protein goal")]
        public double DailyProteinGoal { get; set; }

        [Display(Name ="Daily fat goal")]
        public double DailyFatGoal { get; set; }

        [Display(Name ="Weight goal")]
        public double WeightGoal { get; set; }
    }
}
