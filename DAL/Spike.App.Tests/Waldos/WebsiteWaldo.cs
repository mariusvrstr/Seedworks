using System;
using System.Linq;
using Spike.App.Repositories.Repositories;

namespace Spike.App.Tests.Waldos
{
    public class WebsiteWaldo
    {
        public static Guid GetAnExistingIdByName(WebsiteRepository repo, string name)
        {
            var website = repo.FindAll()
                .First(a => a.CompanyName == name);

            return website.Id;
        }
    }
}
