using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Specifications;
using Spike.Seedworks.Repositories;

namespace Spike.App.Repositories.Repositories
{
    public class BasicWebsiteRepository : RepositoryBase<Website, WebsiteSpecification>
    {
        public BasicWebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}

    }
}
