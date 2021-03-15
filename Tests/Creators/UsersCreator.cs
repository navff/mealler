using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.api.App.Users;
using web.api.DataAccess;

namespace Tests.Creators
{
    public class UsersCreator : BaseCreator, ICreator<User>
    {
        public UsersCreator(AppDbContext context) : base(context)
        {
        }

        public async Task<User> CreateOne()
        {
            var user = new User
            {
                Email = "user1@lololol-hohoho.com",
                Name = "Lololol"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<IEnumerable<User>> CreateMany(int count)
        {
            throw new NotImplementedException();
        }
    }
}