using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyFoodDay.Models
{
    public class UserAdditionalInfo
    {

        [Key]
        public int UserId { get; set; }

        public IdentityUser User { get; set; }   

        public double DailyCalorieGoal { get; set; }

        public double DailyProteinGoal { get; set; }

        public double DailyFatGoal { get; set; }

        public double WeightGoal { get; set; }
    }
}
