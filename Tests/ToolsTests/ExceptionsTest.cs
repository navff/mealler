using Common.Exceptions;
using web.api.App.Users;
using Xunit;

namespace Tests
{
    public class ExceptionsTest
    {
        [Fact]
        public void Test_NotFoundException()
        {
            try
            {
                throw new EntityNotFoundException<User>(123, "Всё плохо");
            }
            catch (EntityNotFoundException<User> e)
            {
                Assert.Contains("123", e.Message);
            }
        }
    }
}