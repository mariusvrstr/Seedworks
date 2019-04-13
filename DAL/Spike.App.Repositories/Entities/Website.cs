using System;
using Spike.Seedworks.Conmmon.DAL;

namespace Spike.App.Repositories.Entities
{
    public class Website : IEntityBase
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
