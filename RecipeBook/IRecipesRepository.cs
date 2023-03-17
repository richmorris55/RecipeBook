using System;
using RecipeBook.Models;

namespace RecipeBook
{
	public interface IRecipesRepository
	{
        public IEnumerable<Recipes> GetAllRecipes();

        public Recipes GetRecipe(int id);

        public void UpdateRecipe(Recipes recipe);

        public void InsertRecipe(Recipes recipeToInsert);

        public IEnumerable<Category> GetCategories();

        public Recipes AssignCategory();

        public void DeleteRecipe(Recipes recipe);


    }

}

