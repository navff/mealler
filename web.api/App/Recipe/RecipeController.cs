using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace web.api.App.Recipe
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController
    {
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return new List<Recipe>()
            {
                new()
                {
                    Description = "This is description v2",
                    Name = "This is name v2"
                }
            };
        } 
    }
}