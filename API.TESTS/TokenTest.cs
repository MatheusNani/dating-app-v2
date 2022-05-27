using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace API.TESTS
{
    public class TokenTest
    {
        [Fact]
        public void Token_CreateToken_ReturnToken_Injection()
        {
            //Arrange
            // utilizar fixture para criar appuser
            var user = new AppUser
            {
                UserName = "User Test"
            };

            // mocks
            var tokenConfiguration = new Mock<IConfiguration>();
            var tokenService = new TokenService(tokenConfiguration.Object);

            //Act
            var token = tokenService.CreateToken(user);

            //Assert
            Assert.False(string.IsNullOrEmpty(token));
        }        
    }
}
