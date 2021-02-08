using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using web.api.App.Recipe;

namespace web.api.DataAccess
{
    public sealed class AppDbContext : DbContext
    {
        static readonly object Locker = new object();
        
        public DbSet<Recipe> Recipes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            lock (Locker)
            {
                Database.Migrate();
            }
        }

        private bool HasUnappliedMigrations()
        {
            var migrationsAssembly = this.GetService<IMigrationsAssembly>();
            var differ = this.GetService<IMigrationsModelDiffer>();

            return differ.HasDifferences(
                migrationsAssembly.ModelSnapshot.Model.GetRelationalModel(),
                this.Model.GetRelationalModel());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}