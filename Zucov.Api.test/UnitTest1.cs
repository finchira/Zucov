using Xunit;
using Zucov.Api.Controllers;
using System;
using System.Linq;

namespace Zucov.Api.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void Get_ReturnsFiveForecasts()
        {
            // Arrange
            var controller = new WeatherController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Length);
        }

        [Fact]
        public void Get_AllForecastDatesAreNotToday()
        {
            // Arrange
            var controller = new WeatherController();
            var today = DateOnly.FromDateTime(DateTime.Now);

            // Act
            var result = controller.Get();

            // Assert

            foreach (var day in result) {
                Assert.True(day.Date > today);
            }
            /*Assert.NotNull(result);
            Assert.All(result, forecast =>
                Assert.NotEqual(today, forecast.Date));*/
        }
    }
}