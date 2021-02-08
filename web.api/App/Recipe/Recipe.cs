using System.ComponentModel.DataAnnotations;

namespace web.api.App.Recipe
{
    public class Recipe
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }
}