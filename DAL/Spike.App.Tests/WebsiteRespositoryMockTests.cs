using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Spike.App.Repositories.Entities;
using Spike.App.Repositories.Repositories;
using Spike.App.Tests.Builders;
using Seedworks.Conmmon.DAL;

namespace Spike.App.Tests
{
    [TestClass]
    public class WebsiteRespositoryMockTests {

        private IRepository<Website> basicWebsiteRepo;
        private const bool USE_MOCKED_SERVICE = true;

        public WebsiteRespositoryMockTests()
        {
            if (USE_MOCKED_SERVICE)
            {
                // Mocked Repository
                basicWebsiteRepo = MockRepository.GenerateMock<IRepository<Website>>();

                basicWebsiteRepo.Stub(e => e.Add(Arg<Website>.Is.Anything))
                    .WhenCalled(x =>
                    {
                        // Return what was passed in
                        x.ReturnValue = (Website)x.Arguments[0];
                    });

                // Always return a Google Website when searching by ID
                basicWebsiteRepo.Stub(e =>
                    e.GetById(Arg<Guid>.Is.Anything)).Return(new WebsiteBuilder().GoogleWebsite().Build());
            }
            else
            {
                basicWebsiteRepo = new BasicWebsiteRepository();
            }
        }

        [TestMethod]
        public void TestAddWebsiteToBasicBase()
        {
            Website response;
            var facebookWebsite = new WebsiteBuilder().FacebookWebsite().Build();

            try
            {
                response = basicWebsiteRepo.Add(facebookWebsite);
                basicWebsiteRepo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
                throw;
            }

            Assert.IsNotNull(response);
            Assert.AreEqual(facebookWebsite.CompanyName, response.CompanyName);
            Assert.AreEqual(facebookWebsite.WebsiteUrl, response.WebsiteUrl);
        }
    }
}
