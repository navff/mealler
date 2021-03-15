using web.api.DataAccess;

namespace Tests.Creators
{
    public class BaseCreator
    {
        public BaseCreator(AppDbContext context)
        {
            _context = context;
        }

        protected AppDbContext _context { get; }
    }
}