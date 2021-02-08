using System.Linq;
using web.api.App.Recipe;

namespace web.api.DataAccess
{
    public class Seeder
    {
        private AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            // Recipes
            this.AddRecipes();
        }
        
        private void AddRecipes()
        {
            if (_context.Recipes.Any()) return;
            _context.Add(new Recipe()
            {
                Name = "Рецепт №1",
                Description = "Описание рецепта №1"
            });
            _context.Add(new Recipe()
            {
                Name = "Рецепт №2",
                Description = "Описание рецепта №2"
            });
            _context.SaveChanges();
        }
    }
}