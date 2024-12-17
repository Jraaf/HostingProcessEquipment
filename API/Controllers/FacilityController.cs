using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilityController : ControllerBase
{
    private readonly IFacilityService _service;

    public FacilityController(IFacilityService service)
    {
        _service = service;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CreateProductionFacilityDTO dto)
    {
        try
        {
            return Ok(await _service.AddAsync(dto));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
