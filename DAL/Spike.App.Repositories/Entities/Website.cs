using Seedworks.Conmmon.DAL;
using System;

namespace Spike.App.Repositories.Entities
{
    public class Website : IEntityBase
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string WebsiteUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
