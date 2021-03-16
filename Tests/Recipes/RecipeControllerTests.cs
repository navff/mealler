using Tests.Creators;
using Tests.ToolsTests;
using web.api.App.Recipes;
using Xunit;

namespace Tests.Recipes
{
    public class RecipeControllerTests
    {
        private readonly RecipeController _controller;
        private readonly Creator _creators;

        public RecipeControllerTests()
        {
            var diServiceBuilder = new DIServiceBuilder();
            _controller = diServiceBuilder.GetService<RecipeController>();
            _creators = new Creator();
        }

        [Fact]
        public void GetRecipe()
        {
            var recipe = _creators.RecipesCreator.CreateOne();
            var result = _controller.Get(new GetRecipeQuery {Id = recipe.Id}).Result;
            Assert.True(result.Id != 0);
        }
    }
}