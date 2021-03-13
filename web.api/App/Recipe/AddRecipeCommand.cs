using MediatR;
using web.api.App.Common;

namespace web.api.App.Recipe
{
    public class AddRecipeCommand : IRequest<EntityCreatedResult>
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }
}