using BLL.DTO;
using BLL.Exceptions;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController(IContractService _service, BackgroundTaskProcessor _taskProcessor) : ControllerBase
{
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
    public async Task<IActionResult> Add(CreateContractDTO dto)
    {
        try
        {
            var contract = await _service.AddAsync(dto);

            _taskProcessor.EnqueueTask(async () =>
            {
                await Task.Delay(1000); 
                Console.WriteLine($"Background processing for Contract {contract.Id} completed.");
            });

            return Ok(contract);
        }
        catch (ContractException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
