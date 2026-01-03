using Asp.Versioning;
using Cycle.Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CycleBike.Adapters.WebApi.Controllers.V1;

[Controller]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
    {
        return Ok();
    }
}