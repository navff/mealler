using Microsoft.Data.Sqlite;

namespace web.api.DataAccess
{
    public static class SqliteConfigBuilder
    {
        public static SqliteConnection GetConnection()
        {
            var connectionString = "DataSource='file::memory:?cache=shared'";    
            // TODO: change this to file storage when needed
            // connectionString = "DataSource==mealler.db";  
            
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            connection.EnableExtensions(true);
            return connection;
        }
    }
}