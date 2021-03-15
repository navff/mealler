using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using web.api.App.Common;
using web.api.App.Recipes.Commands;
using web.api.DataAccess;

namespace web.api.App.Recipes
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public RecipeController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public RecipeResponse Get(GetRecipeQuery query)
        {
            if (query.Id == 0) throw new ArgumentException("No Id!", nameof(query.Id));
            var result = _mediator.Send(query).Result;
            return result;
        }

        [HttpGet("all")]
        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.OrderBy("Description asc").ToList();
        }

        [HttpPost]
        public async Task<EntityCreatedResult> Post([FromBody] AddRecipeCommand command)
        {
            var result = _mediator.Send(command).Result;
            return result;
        }
    }
}