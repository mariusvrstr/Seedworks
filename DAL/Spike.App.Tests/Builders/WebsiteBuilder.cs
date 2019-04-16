using System;
using Spike.App.Repositories.Entities;

namespace Spike.App.Tests.Builders
{
    public class WebsiteBuilder : Website
    {
        public WebsiteBuilder(Guid? id = null)
        {
            this.Id = id ?? Guid.Empty;
            this.CreatedDate = DateTime.Now;
        }

        public WebsiteBuilder UpdateId(Guid id)
        {
            this.Id = id;

            return this;
        }

        public WebsiteBuilder UpdateName (string name)
        {
            this.CompanyName = name;

            return this;
        }

        public WebsiteBuilder FacebookWebsite()
        {
            this.CompanyName = "Facebook";
            this.WebsiteUrl = "https://www.facebook.com";

            return this;
        }

        public WebsiteBuilder GoogleWebsite()
        {
            this.CompanyName = "Google";
            this.WebsiteUrl = "https://www.google.com";

            return this;
        }

        public Website Build()
        {
            return new Website()
            {
                Id = this.Id,
                CompanyName = this.CompanyName,
                WebsiteUrl = this.WebsiteUrl,
                CreatedDate = this.CreatedDate
            };
        }
    }
}
