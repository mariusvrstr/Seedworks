using Inoxico.Scrape.Spike.Repositories;
using Spike.App.Repositories.Entities;
using Spike.Seedworks.Repositories;

namespace Spike.App.Repositories.Repositories
{
    public class WebsiteRepository : RepositoryBase<Website>
    {
        public WebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}
    }
}
