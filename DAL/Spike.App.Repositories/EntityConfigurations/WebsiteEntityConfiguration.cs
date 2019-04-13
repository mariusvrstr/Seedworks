
using System.Data.Entity.ModelConfiguration;
using Spike.App.Repositories.Entities;

namespace Spike.App.Repositories.EntityConfigurations
{
    public class WebsiteEntityConfiguration : EntityTypeConfiguration<Website>
    {
        public WebsiteEntityConfiguration()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.CompanyName).IsRequired().HasMaxLength(100);
            this.Property(m => m.WebsiteUrl).IsRequired().HasMaxLength(300);
        }
    }
}
