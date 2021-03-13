using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace web.api.App.Recipe
{
    public class GetRecipeQuery : IRequest<RecipeResponse>
    {
        [BindRequired] [FromRoute] public int Id { get; set; }
    }
}