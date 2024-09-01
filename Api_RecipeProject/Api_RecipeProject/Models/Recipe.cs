using System.ComponentModel.DataAnnotations;

namespace Api_RecipeProject.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Components { get; set; }
        public string Preparation { get; set; }
         
    }
}
