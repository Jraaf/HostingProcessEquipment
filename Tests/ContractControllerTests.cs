using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Controllers;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using BLL.Services;

namespace Tests;

[TestFixture]
public class ContractControllerTests
{
    private Mock<IContractService> _serviceMock;
    private Mock<BackgroundTaskProcessor> _taskProcessorMock;
    private ContractController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<IContractService>();
        var fakeTaskProcessor = new FakeBackgroundTaskProcessor();
        _controller = new ContractController(_serviceMock.Object, fakeTaskProcessor);
    }


    [Test]
    public async Task GetAll_ReturnsOkResult_WithListOfContracts()
    {
        // Arrange
        var mockContracts = new List<ContractDTO>
        {
            new ContractDTO { Id = 1, FacilityId = 1, EquipmentId = 1, FacilityName = "Facility A", EquipmentTypeName = "Type A", EquipmentCount = 5 },
            new ContractDTO { Id = 2, FacilityId = 2, EquipmentId = 2, FacilityName = "Facility B", EquipmentTypeName = "Type B", EquipmentCount = 10 }
        };
        _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(mockContracts);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(mockContracts, okResult.Value);
    }

    [Test]
    public async Task GetAll_ReturnsNotFound_WhenNoContractsFound()
    {
        // Arrange
        _serviceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(new NotFoundException());

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task GetAll_ReturnsStatusCode500_OnException()
    {
        // Arrange
        _serviceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<ObjectResult>(result);
        var objectResult = result as ObjectResult;
        Assert.NotNull(objectResult);
        Assert.AreEqual(500, objectResult.StatusCode);
    }

    [Test]
    public async Task Add_ReturnsOkResult_WhenContractAdded()
    {
        // Arrange
        var dto = new CreateContractDTO { FacilityId = 1, EquipmentId = 1, EquipmentCount = 5 };
        var addedContract = new ContractDTO
        {
            Id = 1,
            FacilityId = 1,
            EquipmentId = 1,
            FacilityName = "Facility A",
            EquipmentTypeName = "Type A",
            EquipmentCount = 5
        };

        _serviceMock.Setup(s => s.AddAsync(dto)).ReturnsAsync(addedContract);

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(addedContract, okResult.Value);
    }

    [Test]
    public async Task Add_ReturnsBadRequest_WhenContractExceptionThrown()
    {
        // Arrange
        var dto = new CreateContractDTO { FacilityId = 1, EquipmentId = 1, EquipmentCount = 5 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ThrowsAsync(new ContractException("Invalid contract"));

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.NotNull(badRequestResult);
        Assert.AreEqual("Invalid contract", badRequestResult.Value);
    }

    [Test]
    public async Task Add_ReturnsStatusCode500_OnException()
    {
        // Arrange
        var dto = new CreateContractDTO { FacilityId = 1, EquipmentId = 1, EquipmentCount = 5 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ThrowsAsync(new Exception("Unexpected error"));

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<ObjectResult>(result);
        var objectResult = result as ObjectResult;
        Assert.NotNull(objectResult);
        Assert.AreEqual(500, objectResult.StatusCode);
        Assert.AreEqual("Unexpected error", objectResult.Value);
    }
}
