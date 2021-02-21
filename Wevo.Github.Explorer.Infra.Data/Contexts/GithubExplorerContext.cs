using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wevo.Github.Explore.Domain.Entities;

namespace Wevo.Github.Explorer.Infra.Data.Contexts
{
    public class GithubExplorerContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public GithubExplorerContext(IConfiguration configuration, DbContextOptions<GithubExplorerContext> options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
