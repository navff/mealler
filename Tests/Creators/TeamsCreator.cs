using System;
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

        public Task<Team> CreateOne()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> CreateMany(int count)
        {
            throw new NotImplementedException();
        }
    }
}