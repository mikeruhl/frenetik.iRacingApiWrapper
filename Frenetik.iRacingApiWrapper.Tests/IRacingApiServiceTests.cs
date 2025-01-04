using Frenetik.iRacingApiWrapper.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Frenetik.iRacingApiWrapper.Tests
{
    public class IRacingApiServiceTests
    {
        private readonly Mock<IOptions<IRacingDataSettings>> _mockSettings;
        private readonly Mock<ILogger<IRacingApiService>> _mockLogger;
        private readonly IRacingApiService _service;

        public IRacingApiServiceTests()
        {
            _mockSettings = new Mock<IOptions<IRacingDataSettings>>();
            _mockLogger = new Mock<ILogger<IRacingApiService>>();

            var settings = new IRacingDataSettings
            {
                BaseUrl = "https://api.iracing.com",
                Username = "testuser",
                Password = "testpassword"
            };

            _mockSettings.Setup(s => s.Value).Returns(settings);

            _service = new IRacingApiService(_mockSettings.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetDoc_ShouldReturnEndpointDetails()
        {
            // Arrange

            // Act
            var result = await _service.GetDoc();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetConstantsCategories_ShouldReturnConstants()
        {
            // Arrange

            // Act
            var result = await _service.GetConstantsCategories();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCarAssets_ShouldReturnCarAssets()
        {
            // Arrange

            // Act
            var result = await _service.GetCarAssets();

            // Assert
            Assert.NotNull(result);
        }

        // Add more tests for other methods as needed
    }
}
