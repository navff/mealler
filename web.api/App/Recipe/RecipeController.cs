using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using web.api.DataAccess;

namespace web.api.App.Recipe
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController
    {
        private AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Very good controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return new List<Recipe>()
            {
                new()
                {
                    Description = "This is description v4 develop",
                    Name = "This is name v4 develop"
                }
            };
        } 
        
        [HttpGet("all")]
        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.ToList();
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            _context.Recipes.Add(new Recipe
            {
                Description = "This is desc",
                Name = "This is name"
            });
            _context.SaveChanges();
            return new OkResult();
        } 
    }
}