using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Repositories;
using Spike.App.Repositories.Specifications;
using Spike.App.Tests.Builders;
using Spike.App.Tests.Waldos;

namespace Spike.App.Tests
{
    [TestClass]
    public class WebsiteRepositoryTests
    {
        private WebsiteRepository websiteRepo;
        private BasicWebsiteRepository basicWebsiteRepo;

        public WebsiteRepositoryTests()
        {
            websiteRepo = new WebsiteRepository();
            basicWebsiteRepo = new BasicWebsiteRepository();
        }

        [TestMethod]
        public void TestAddWebsiteToBasicBase()
        {
            Website response;
            var website = new WebsiteBuilder().FacebookWebsite().Build();

            try
            {
                response = basicWebsiteRepo.Add(website);
                websiteRepo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            Assert.IsNotNull(response);
            Assert.AreEqual(website.CompanyName, response.CompanyName);
            Assert.AreEqual(website.WebsiteUrl, response.WebsiteUrl);
        }


        [TestMethod]
        public void TestAddWebsiteToSpecificationBase()
        {
            Website response;
            var website = new WebsiteBuilder().FacebookWebsite().Build();

            try
            {
                response = websiteRepo.Add(website);
                websiteRepo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            Assert.IsNotNull(response);
            Assert.AreEqual(website.CompanyName, response.CompanyName);
            Assert.AreEqual(website.WebsiteUrl, response.WebsiteUrl);
        }

        [TestMethod]
        public void TestUpdatedWebsite()
        {
            Website response;
            var id = WebsiteWaldo.GetAnExistingIdByName(websiteRepo, "Facebook");
            var website = new WebsiteBuilder(id).FacebookWebsite().UpdateName("Facebook Updated").Build();

            try
            {
                response = websiteRepo.Update(id, website);
                websiteRepo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            Assert.IsNotNull(response);
            Assert.AreEqual(website.CompanyName, response.CompanyName);
            Assert.AreEqual(website.WebsiteUrl, response.WebsiteUrl);
        }

        [TestMethod]
        public void TestDeleteWebsite()
        {
            Website response;
            var id = WebsiteWaldo.GetAnExistingIdByName(websiteRepo, "Facebook Updated");

            try
            {
                websiteRepo.Remove(id);
                websiteRepo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }
        }


        [TestMethod]
        public void TestWebsiteSpecification()
        {
            IEnumerable<Website> websites = null;

            try
            {
                var spes = new WebsiteSpecification();
                spes.CompanyNameStartingWith("Face");

                websites = websiteRepo.FindUsingSpecification(spes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            foreach (var website in websites)
            {
                Console.Write(website.CompanyName);
            }
        }
    }
}
