using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Repositories;
using Spike.App.Tests.Builders;

namespace Spike.App.Tests
{
    [TestClass]
    public class WebsiteRepositoryTests
    {
        private WebsiteRepository websiteRepo;

        public WebsiteRepositoryTests()
        {
            websiteRepo = new WebsiteRepository();
        }

        [TestMethod]
        public void TestAddWebsite()
        {
            Website response;
            var website = new WebsiteBuilder().FacebookWebsite().Build();

            try
            {
                response = websiteRepo.Add(website);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            Assert.IsNotNull(response);
            Assert.Equals(website.CompanyName, response.CompanyName);
            Assert.Equals(website.WebsiteUrl, response.WebsiteUrl);
            Assert.AreNotEqual(website.Id, response.Id);
        }
    }
}
