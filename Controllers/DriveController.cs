using ANEFreeInIty_Server_API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ANEFreeInIty_Server_API.Controllers;

[ApiController]
[Route("[controller]")]
public class DriveController : ControllerBase
{
    private readonly IServiceManager _service;

    public DriveController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("mal")]
    public async Task<IActionResult> GetMALs()
    {
        var mals = await _service.MALService.GetMALsServiceAsync();
        return Ok(mals);
    }

    [HttpGet("mal/{id}")]
    public async Task<IActionResult> GetMAL(int id)
    {
        var mal = await _service.MALService.GetMALServiceByIdAsync(id);
        return mal == null ? NotFound() : Ok(mal);
    }

    [HttpPost]
    [Route("mal")]
    public async Task<IActionResult> AddMAL(MAL mal)
    {
        var result = await _service.MALService.AddMALServiceAsync(mal);
        return CreatedAtAction(nameof(GetMAL), new { id = result }, mal);
    }

    [HttpPut("mal/{id}")]
    public async Task<IActionResult> UpdateMAL(int id, MAL mal)
    {
        if (id != mal.Id)
        {
            return BadRequest("MAL ID mismatch.");
        }

        var existingMAL = await _service.MALService.GetMALServiceByIdAsync(id);
        if (existingMAL == null)
        {
            return NotFound();
        }

        await _service.MALService.UpdateMALServiceAsync(mal);
        return NoContent();
    }

    [HttpDelete("mal/{id}")]
    public async Task<IActionResult> DeleteMAL(int id)
    {
        var existingMAL = await _service.MALService.GetMALServiceByIdAsync(id);
        if (existingMAL == null)
        {
            return NotFound();
        }

        await _service.MALService.DeleteMALServiceAsync(id);
        return NoContent();
    }

    [HttpGet]
    [Route("test")]
    public IActionResult Get()
    {
        return Ok("CONNECTED");
    }

    [HttpPost]
    public async Task<IActionResult> SaveFile(IFormFile file, int chunkIndex, string fileName)
    {
        await _service.DriveService.SaveFileServiceAsync(file, chunkIndex, fileName);
        return Ok(new { message = $"Chunk {chunkIndex} uploaded successfully." });
    }

    [HttpGet]
    [Route("DownloadFile")]
    public IActionResult DownloadFile(string fileName)
    {
        var response = _service.DriveService.DownloadFileService(fileName);
        return File(response.FileBytes, response.ContentType, response.FileName);
    }
}
