using System.Collections.Generic;
using System.Threading.Tasks;
using web.api.App.Teams;
using web.api.DataAccess;

namespace Tests.Creators
{
    public class TeamsCreator : BaseCreator, ICreator<Team>
    {
        public TeamsCreator(AppDbContext context) : base(context)
        {
        }

        public async Task<Team> CreateOne()
        {
            var userCreator = new UsersCreator(_context);
            var owner = await userCreator.CreateOne();

            var team = new Team
            {
                Name = "Team",
                Owner = owner,
                OwnerUserId = owner.Id,
                Members = await userCreator.CreateMany(5)
            };

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<List<Team>> CreateMany(int count)
        {
            var userCreator = new UsersCreator(_context);
            var owner = await userCreator.CreateOne();
            var addedTeams = new List<Team>();

            for (var i = 0; i < count; i++)
            {
                var team = new Team
                {
                    Name = $"Team{i}",
                    Owner = owner,
                    OwnerUserId = owner.Id,
                    Members = await userCreator.CreateMany(5)
                };
                addedTeams.Add(team);
            }

            await _context.AddRangeAsync(addedTeams);
            await _context.SaveChangesAsync();
            return addedTeams;
        }
    }
}