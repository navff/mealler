using System.ComponentModel.DataAnnotations;

namespace web.api.App.Ingredient
{
    public class Ingredient
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public double AvgPrice { get; set; }
    }
}