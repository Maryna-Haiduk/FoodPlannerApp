using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPlannerApp.Models
{
    public class Recipe
    {
        public int Id { get; set; } // Primary Key
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; } // URL or File Path
        [Required]
        public List<string> Ingredients { get; set; } = new List<string>();
        public string Instructions { get; set; }
        // public string Type { get; set; } // Example: "Breakfast", "Lunch", etc.

    }
}
