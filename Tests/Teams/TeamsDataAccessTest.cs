using Xunit;

namespace Tests.Teams
{
    public class TeamsDataAccessTest : BaseUnitTest
    {
        [Fact]
        public void AddTeams()
        {
            var result = _creator.TeamsCreator.CreateMany(5).Result;
            Assert.All(result, team =>
            {
                Assert.True(team.Id != 0);
                Assert.True(team.Members.Count == 5);
            });
        }
    }
}