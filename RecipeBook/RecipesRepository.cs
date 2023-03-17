using System;
using System.Data;
using Dapper;
using RecipeBook.Models;

namespace RecipeBook
{
	public class RecipesRepository : IRecipesRepository
	{
        private readonly IDbConnection _conn;

        public RecipesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Recipes> GetAllRecipes()
        {
            return _conn.Query<Recipes>("SELECT * FROM RECIPES;");

        }

        public Recipes GetRecipe(int id)
        {
            return _conn.QuerySingle<Recipes>("SELECT * FROM RECIPES WHERE RECIPEID = @id", new { id = id });
        }

        public void UpdateRecipe(Recipes recipe)
        {
            _conn.Execute("UPDATE recipes SET Name = @name, Cuisine = @cuisine, Description = @description, TotalCookingTime = @totalcookingtime, Servings = @servings, IngredientsWithMeasurements = @ingredientswithmeasurements, CookingInstructions = @cookinginstructions, NotesAndFAQs = @notesandfaqs, NutritionFacts = @nutritionfacts WHERE RecipeID = @id",
             new { name = recipe.Name, cuisine = recipe.Cuisine, description = recipe.Description, totalcookingtime = recipe.TotalCookingTime, servings = recipe.Servings, ingredientswithmeasurements = recipe.IngredientsWithMeasurements, cookinginstructions = recipe.CookingInstructions, notesandfaqs = recipe.NotesAndFAQs, nutritionfacts = recipe.NutritionFacts, id = recipe.RecipeID });
        }

        public void InsertRecipe(Recipes recipeToInsert)
        {
            _conn.Execute("INSERT INTO recipes (NAME, CUISINE, DESCRIPTION, TOTALCOOKINGTIME, SERVINGS, INGREDIENTSWITHMEASUREMENTS, COOKINGINSTRUCTIONS, NOTESANDFAQS, NUTRITIONFACTS, CATEGORYID) VALUES (@name, @cuisine, @description, @totalcookingtime, @servings, @ ingredientswithmeasurements, @cookinginstructions, @notesandfaqs, @nutritionfacts, @categoryID",
        
                new { name = recipeToInsert.Name, cuisine = recipeToInsert.Cuisine, description = recipeToInsert.Description, totalcookingtime = recipeToInsert.TotalCookingTime, servings = recipeToInsert.Servings, ingredientswithmeasurements = recipeToInsert.IngredientsWithMeasurements, cookinginstructions = recipeToInsert.CookingInstructions, notesandfaqs = recipeToInsert.NotesAndFAQs, nutritionfacts = recipeToInsert.NutritionFacts, categoryID = recipeToInsert.CategoryID });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Recipes AssignCategory()
        {
            var categoryList = GetCategories();
            var recipe = new Recipes();
            recipe.Categories = categoryList;
            return recipe;
        }

        public void DeleteRecipe(Recipes recipe)
        {
            _conn.Execute("DELETE FROM RECIPES WHERE RecipeID = @id;", new { id = recipe.RecipeID });

        }




    }
}

