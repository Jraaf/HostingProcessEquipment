using API.Controllers;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests;

[TestFixture]
public class FacilityControllerTests
{
    private Mock<IFacilityService> _serviceMock;
    private FacilityController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<IFacilityService>();
        _controller = new FacilityController(_serviceMock.Object);
    }

    [Test]
    public async Task GetAll_ReturnsOkResult_WithListOfFacilities()
    {
        // Arrange
        var mockFacilities = new List<ProductionFacilityDTO>
        {
            new ProductionFacilityDTO { Id = 1, Name = "Facility A", Area = 1500.0 },
            new ProductionFacilityDTO { Id = 2, Name = "Facility B", Area = 2000.0 }
        };
        _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(mockFacilities);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(mockFacilities, okResult.Value);
    }

    [Test]
    public async Task GetAll_ReturnsNotFound_WhenNoFacilitiesFound()
    {
        // Arrange
        _serviceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(new NotFoundException());

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Add_ReturnsOkResult_WhenFacilityAdded()
    {
        // Arrange
        var dto = new CreateProductionFacilityDTO { Name = "Facility X", Area = 2500.0 };
        var addedFacility = new ProductionFacilityDTO { Id = 1, Name = "Facility X", Area = 2500.0 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ReturnsAsync(addedFacility);

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(addedFacility, okResult.Value);
    }

    [Test]
    public async Task Add_ReturnsBadRequest_WhenContractExceptionThrown()
    {
        // Arrange
        var dto = new CreateProductionFacilityDTO { Name = "Invalid Facility", Area = 0.0 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ThrowsAsync(new ContractException("Invalid facility"));

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.NotNull(badRequestResult);
        Assert.AreEqual("Invalid facility", badRequestResult.Value);
    }
}
