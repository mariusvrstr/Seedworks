using Seedworks.Repositories;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Specifications;

namespace Spike.App.Repositories.Repositories
{
    public class WebsiteRepository : RepositoryBase<Website, WebsiteSpecification>
    {
        public WebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}

    }
}
