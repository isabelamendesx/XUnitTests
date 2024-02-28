using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NAME - ClassName_MethodName_ExpectedResult

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            var networkService = new NetworkService();

            // Act
            var result = networkService.SendPing();

            // Assert 
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Sucess: Ping Sent!"); // Maybe too strict
            result.Should().Contain("Sucess", Exactly.Once()); // Middle
        }

        [Theory]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeOut_ReturnInt(int a, int b, int expectedResult)
        {
            var networkService = new NetworkService();

            var result = networkService.PingTimeOut(a, b);

            result.Should().Be(expectedResult);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
