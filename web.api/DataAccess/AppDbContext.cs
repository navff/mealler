using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
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
            Database.EnsureCreated();
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
        
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => 
                    opt.UseSqlite(SqliteConfigBuilder.GetConnection()),
                ServiceLifetime.Transient);
            
            var context = services.BuildServiceProvider()
                .GetService<AppDbContext>();
            
            var seeder = new Seeder(context);
            seeder.Seed();
        }
    }
}