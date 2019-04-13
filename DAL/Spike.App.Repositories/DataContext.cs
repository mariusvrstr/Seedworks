using System.Data.Entity;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.EntityConfigurations;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Inoxico.Scrape.Spike.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=InoxicoScrapeConnection") // Connection String
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WebsiteEntityConfiguration());
        }

        public DbSet<Website> Websites { get; set; }
    }
}
