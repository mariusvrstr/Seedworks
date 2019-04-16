using System.Data.Entity;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.EntityConfigurations;

namespace Spike.App.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=SpikeAppConnection") // Connection String Name
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
