using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace web.api.App.Recipe
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeResponse>
    {
        public Task<RecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}