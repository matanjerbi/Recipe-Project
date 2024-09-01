using Microsoft.AspNetCore.Mvc;
using Api_RecipeProject.Models;

namespace Api_RecipeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase // שימוש ב-ControllerBase ב-API במקום Controller
    {
        private static List<Recipe> recipes = new List<Recipe>(); // רשימה סטטית כדי לשמור נתונים בין בקשות
        // Create a new recipe
        [HttpPost]
        [Route("CreateRecipe")]
        public ActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipes.Add(recipe);
                return Ok(new { message = "Recipe created successfully", recipe });
            }
            return BadRequest(ModelState); 
        }

        // Get all recipes
        [HttpGet]
        [Route("GetRecipes")]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            return Ok(recipes); 
        }

        // Edit a recipe
        [HttpPut]
        [Route("EditRecipe/{id}")]
        public ActionResult EditRecipe(int id, [FromBody] Recipe updatedRecipe)
        {
            var recipe = recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound(new { message = "Recipe not found" });
            }

            recipe.Name = updatedRecipe.Name; 
            recipe.Components = updatedRecipe.Components;
            recipe.Preparation = updatedRecipe.Preparation;

            return Ok(new { message = "Recipe updated successfully", recipe });
        }

        // Delete a recipe
        [HttpDelete]
        [Route("DeleteRecipe/{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound(new { message = "Recipe not found" });
            }

            recipes.Remove(recipe);
            return Ok(new { message = "Recipe deleted successfully" });
        }
    }
}
