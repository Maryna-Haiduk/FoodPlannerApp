using System.Collections.Generic;

namespace FoodPlannerApp.Models
{
    public class Recipe
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; } // URL or File Path
        public List<string> Ingredients { get; set; } = new List<string>();
        public string Instructions { get; set; }
        public string Type { get; set; } // Example: "Breakfast", "Lunch", etc.
    }
}
