using System.Threading;
using System.Threading.Tasks;
using MediatR;
using web.api.App.Common;

namespace web.api.App.Recipe
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, EntityCreatedResult>
    {
        private readonly RecipeService _recipeService;

        public AddRecipeCommandHandler(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        public async Task<EntityCreatedResult> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var resultRecipe = await _recipeService.Add(new Recipe
            {
                Description = request.Description,
                Name = request.Name
            });

            return new EntityCreatedResult
            {
                Id = resultRecipe.Id
            };
        }
    }
}