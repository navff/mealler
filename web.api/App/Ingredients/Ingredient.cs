using System.ComponentModel.DataAnnotations;

namespace web.api.App.Ingredients
{
    public class Ingredient
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public double AvgPrice { get; set; }
    }
}