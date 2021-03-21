using System.Threading.Tasks;
using AliFitnessAE.Models.TokenAuth;
using AliFitnessAE.Web.Controllers;
using Shouldly;
using Xunit;

namespace AliFitnessAE.Web.Tests.Controllers
{
    public class HomeController_Tests: AliFitnessAEWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}