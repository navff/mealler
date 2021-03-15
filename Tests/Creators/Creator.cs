using Tests.ToolsTests;
using web.api.DataAccess;

namespace Tests.Creators
{
    public class Creator
    {
        public Creator()
        {
            var builder = new DIServiceBuilder();
            var context = builder.GetService<AppDbContext>();
            UsersCreator = new UsersCreator(context);
            TeamsCreator = new TeamsCreator(context);
        }

        public UsersCreator UsersCreator { get; }
        public TeamsCreator TeamsCreator { get; }
    }
}