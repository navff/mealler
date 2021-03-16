using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.api.App.Recipes;
using web.api.DataAccess;

namespace Tests.Creators
{
    public class RecipesCreator : BaseCreator, ICreator<Recipe>
    {
        public RecipesCreator(AppDbContext context) : base(context)
        {
        }

        public async Task<Recipe> CreateOne()
        {
            var recipe = new Recipe
            {
                Name = "Recipe",
                Description = "This is recipe description"
            };
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();

            return recipe;
        }

        public Task<List<Recipe>> CreateMany(int count)
        {
            throw new NotImplementedException();
        }
    }
}