﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using web.api.App.Recipes;
using web.api.App.Teams;
using web.api.App.Users;

namespace web.api.DataAccess
{
    public sealed class AppDbContext : DbContext
    {
        private static readonly object Locker = new object();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            lock (Locker)
            {
                Database.Migrate();
            }
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(z => z.OwnerUserId);

            modelBuilder.Entity<Team>()
                .HasMany(p => p.Members)
                .WithMany(p => p.Teams);
        }

        private bool HasUnappliedMigrations()
        {
            var migrationsAssembly = this.GetService<IMigrationsAssembly>();
            var differ = this.GetService<IMigrationsModelDiffer>();

            return differ.HasDifferences(
                migrationsAssembly.ModelSnapshot.Model.GetRelationalModel(),
                Model.GetRelationalModel());
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