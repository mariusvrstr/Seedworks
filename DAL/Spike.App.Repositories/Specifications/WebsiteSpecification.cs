using System;
using Spike.App.Repositories.Entities;
using Spike.Seedworks.Repositories.Specification;

namespace Spike.App.Repositories.Specifications
{
    public class WebsiteSpecification : Specification<Website, WebsiteSpecification>
    {
        public WebsiteSpecification CreatedFrom(DateTime date)
        {
            return
                Clause(website => website.CreatedDate > date)
                    .Clause(website => website.CreatedDate > DateTime.Now.AddYears(-500));
        }

        public WebsiteSpecification CompanyNameStartingWith(string name)
        {
            return Clause(website => website.CompanyName.StartsWith(name));
        }
    }
}
