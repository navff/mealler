using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;

namespace web.api.App.Recipes.Queries
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeResponse>
    {
        private readonly RecipeService _recipeService;

        public GetRecipeQueryHandler(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<RecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeService.Get(request.Id);
            return recipe.Adapt<RecipeResponse>();
        }
    }
}