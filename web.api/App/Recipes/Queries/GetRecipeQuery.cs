using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace web.api.App.Recipes
{
    public class GetRecipeQuery : IRequest<RecipeResponse>
    {
        [FromRoute] public int Id { get; set; }
    }
}