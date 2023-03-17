using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipesRepository repo;

        public RecipesController(IRecipesRepository repo)
        {
            this.repo = repo;
        }

            // GET: /<controller>/
            public IActionResult Index()
            {

            var recipes = repo.GetAllRecipes();
            return View(recipes);

            }

        public IActionResult ViewRecipe(int id)
        {
            var recipe = repo.GetRecipe(id);
            return View(recipe);
        }

        public IActionResult UpdateRecipe(int id)
        {
            Recipes recipe = repo.GetRecipe(id);
            if (recipe == null)
            {
                return View("RecipeNotFound");
            }
            return View(recipe);
        }

        public IActionResult UpdateRecipeToDatabase(Recipes recipe)
        {
            repo.UpdateRecipe(recipe);

            return RedirectToAction("ViewRecipe", new { id = recipe.RecipeID });
        }

        public IActionResult InsertRecipe()
        {
            var recipe = repo.AssignCategory();
            return View(recipe);
        }

        public IActionResult InsertRecipeToDatabase(Recipes recipeToInsert)
        {
            repo.InsertRecipe(recipeToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRecipe(Recipes recipe)
        {
            repo.DeleteRecipe(recipe);
            return RedirectToAction("Index");
        }




    }

}

