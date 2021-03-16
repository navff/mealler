using Tests.Creators;
using web.api.DataAccess;

namespace Tests
{
    public class BaseUnitTest
    {
        protected AppDbContext _context;
        protected Creator _creator;

        public BaseUnitTest()
        {
            _creator = new Creator();
            _context ??= _creator.GetContext();
        }
    }
}