using Tests.Creators;
using Tests.ToolsTests;
using web.api.DataAccess;

namespace Tests
{
    public class BaseUnitTest
    {
        protected AppDbContext _context;
        protected Creator _creator;

        public BaseUnitTest()
        {
            // must be the first because it initialises DB Context
            _creator = new Creator();
            var diServiceBuilder = new DIServiceBuilder();
            _context = diServiceBuilder.GetService<AppDbContext>();
        }
    }
}