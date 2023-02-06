using IdentityServer4.EntityFramework.Options;
using LetsBeReal.Server.Configurations.Entities;
using LetsBeReal.Server.Models;
using LetsBeReal.Shared;
using LetsBeReal.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsBeReal.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Reviews> Review { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Update> News { get; set; }
        public DbSet<UserInterest> Interests { get; set; }
        public DbSet<Games> Game { get; set; }
        public DbSet<Product> TechStore { get; set; }
        public DbSet<UserRank> UserRank { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
