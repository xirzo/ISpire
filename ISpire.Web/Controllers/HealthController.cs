using ISpire.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISpire.Web.Controllers;

[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("health")]
    public IActionResult GetHealth()
    {
        return Ok("Healthy");
    }
    
    [HttpGet("authorized/health")]
    [Authorize(Policy = Permissions.Read)]
    public IActionResult GetAuthorizedHealth()
    {
        return Ok("Healthy");
    }
}