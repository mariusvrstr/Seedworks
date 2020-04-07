using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Specifications;
using Spike.Seedworks.Repositories;

namespace Spike.App.Repositories.Repositories
{
    public class WebsiteRepository : RepositoryBase<Website, WebsiteSpecification>
    {
        public WebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}

    }
}
