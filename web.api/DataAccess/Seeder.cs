using System.Linq;
using web.api.App.Recipes;
using web.api.App.Teams;
using web.api.App.Users;

namespace web.api.DataAccess
{
    public class Seeder
    {
        private readonly AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            // Recipes
            AddRecipes();
        }

        private void AddUsers()
        {
            var petya = new User
            {
                Name = "Petya (Team Admin)",
                Email = "petya@petya-team.com"
            };

            var vasya = new User
            {
                Name = "Vasya (Team member)",
                Email = "masya@petya-team.com"
            };

            var tanya = new User
            {
                Name = "Tanya (Team member)",
                Email = "tanya@petya-team.com"
            };

            var vova = new User
            {
                Name = "Vova (Team admin and member",
                Email = "Var@33kita.ru"
            };

            // Teams
            var petyaTeam = new Team
            {
                Name = "PetyaTeam",
                Owner = petya,
                Members = {tanya, vasya, vova}
            };

            var vovaTeam = new Team
            {
                Name = "VovaTeam",
                Owner = vova,
                Members = {tanya, vasya}
            };

            _context.Teams.Add(petyaTeam);
            _context.Teams.Add(vovaTeam);
        }

        private void AddRecipes()
        {
            if (_context.Recipes.Any()) return;
            _context.Add(new Recipe
            {
                Name = "Рецепт №1",
                Description = "Описание рецепта №1"
            });
            _context.Add(new Recipe
            {
                Name = "Рецепт №2",
                Description = "Описание рецепта №2"
            });
            _context.Add(new Recipe
            {
                Name = "Рецепт №3",
                Description = "Неожиданно ещё одно описание"
            });
            _context.Add(new Recipe
            {
                Name = "Рецепт №4",
                Description = "А тут описание с буквы А"
            });
            _context.Add(new Recipe
            {
                Name = "Рецепт №5",
                Description = "Бля! Ещё один рецепт"
            });
            _context.SaveChanges();
        }
    }
}