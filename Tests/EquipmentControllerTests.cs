using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Controllers;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Interfaces;

namespace Tests;
[TestFixture]
public class EquipmentControllerTests
{
    private Mock<IEquipmentService> _serviceMock;
    private EquipmentController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<IEquipmentService>();
        _controller = new EquipmentController(_serviceMock.Object);
    }

    [Test]
    public async Task GetAll_ReturnsOkResult_WithListOfEquipment()
    {
        // Arrange
        var mockEquipment = new List<EquipmentDTO>
        {
            new EquipmentDTO { Id = 1, Name = "Equipment 1", Area = 50.0 },
            new EquipmentDTO { Id = 2, Name = "Equipment 2", Area = 75.5 }
        };
        _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(mockEquipment);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(mockEquipment, okResult.Value);
    }

    [Test]
    public async Task GetAll_ReturnsNotFound_WhenNoEquipmentFound()
    {
        // Arrange
        _serviceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(new NotFoundException());

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Add_ReturnsOkResult_WhenEquipmentAdded()
    {
        // Arrange
        var dto = new CreateEquipmentDTO { Name = "New Equipment", Area = 100.5 };
        var addedEquipment = new EquipmentDTO { Id = 1, Name = "New Equipment", Area = 100.5 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ReturnsAsync(addedEquipment);

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(addedEquipment, okResult.Value);
    }

    [Test]
    public async Task Add_ReturnsBadRequest_WhenContractExceptionThrown()
    {
        // Arrange
        var dto = new CreateEquipmentDTO { Name = "Invalid Equipment", Area = 0.0 };
        _serviceMock.Setup(s => s.AddAsync(dto)).ThrowsAsync(new ContractException("Invalid equipment"));

        // Act
        var result = await _controller.Add(dto);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.NotNull(badRequestResult);
        Assert.AreEqual("Invalid equipment", badRequestResult.Value);
    }
}
