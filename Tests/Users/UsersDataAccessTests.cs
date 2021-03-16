using Xunit;

namespace Tests.Users
{
    public class UsersDataAccessTests : BaseUnitTest
    {
        [Fact]
        public void GetUser()
        {
            var usr = _creator.UsersCreator.CreateOne().Result;
            Assert.NotNull(usr);
            Assert.False(usr.Id == 0);
        }

        [Fact]
        public void GetUsers()
        {
            var users = _creator.UsersCreator.CreateMany(6).Result;
            Assert.NotNull(users);
            Assert.All(users, user => { Assert.True(user.Id != 0); });
        }
    }
}