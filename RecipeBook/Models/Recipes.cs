using System;
namespace RecipeBook.Models
{
	public class Recipes
	{
		

		public int RecipeID { get; set; }

        public string? Name { get; set; }

        public string? Cuisine { get; set; }

        public string? Description { get; set; }

        public string? TotalCookingTime { get; set; }

        public int Servings { get; set; }

        public string? IngredientsWithMeasurements { get; set; }

        public string? CookingInstructions { get; set; }

        public string? NotesAndFAQs { get; set; }

        public string? NutritionFacts { get; set; }

        public int CategoryID { get; set; }

        public IEnumerable<Category>? Categories { get; set; }


    }
}

