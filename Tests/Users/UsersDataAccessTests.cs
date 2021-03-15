using Xunit;

namespace Tests.Users
{
    public class UsersDataAccessTests : BaseUnitTest
    {
        [Fact]
        public async void GetUsers()
        {
            var usr = await _creator.UsersCreator.CreateOne();
            Assert.NotNull(usr);
            Assert.False(usr.Id == 0);
        }
    }
}