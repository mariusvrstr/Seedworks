using System.Collections.Generic;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Specifications;
using Spike.Seedworks.Repositories;
using Spike.Seedworks.Repositories.Specification;

namespace Spike.App.Repositories.Repositories
{
    public class WebsiteRepository : RepositoryBase<Website, WebsiteSpecification>
    {
        public WebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}

    }
}
