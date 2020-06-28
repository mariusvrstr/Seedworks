using Spike.App.Repositories.Entities;
using Seedworks.Repositories;

namespace Spike.App.Repositories.Repositories
{
    public class BasicWebsiteRepository : RepositorySimpleBase<Website>
    {
        public BasicWebsiteRepository(DataContext context = null) 
            : base(context ?? new DataContext()) {}

    }
}
