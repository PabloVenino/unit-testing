using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - variables, classes, mocks
            var pingService = new NetworkService();

            // Act
            var result = pingService.SendPing();

            // Assert
            result.Should().Contain("Success", Exactly.Once());
            result.Should().StartWith("S");
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: Ping Sent!");

        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 1, 1)]
        [InlineData(2, 2, 4)]
        public void NetworkService_Sum_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            //int a = 1;
            //int b = 1;
            var networkService = new NetworkService();

            // Act
            var result = networkService.Sum(a, b);

            // Assert
            result.Should().BeGreaterThanOrEqualTo(0);
            result.Should().BePositive();
            result.Should().BeInRange(0, int.MaxValue);
            result.Should().Be(expected);

        }
    }
}
