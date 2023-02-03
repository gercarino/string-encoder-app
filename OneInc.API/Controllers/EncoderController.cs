using Microsoft.AspNetCore.Mvc;
using OneInc.API.Api.Queries;
using OneInc.API.Interfaces;

namespace OneInc.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncoderController : ControllerBase
{
    private readonly ILogger<EncoderController> _logger;
    private readonly IEncodingService _service;

    public EncoderController(ILogger<EncoderController> logger, IEncodingService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    [Route("delay")]
    public IAsyncEnumerable<char> Delay([FromBody] EncodeStringQuery request, CancellationToken cancellationToken = default)
    {
        try
        {
            return _service.EncodeAsync(request.Value, cancellationToken);
        }
        catch (Exception)
        {
            _logger.LogError(nameof(Delay));
            throw;
        }
    }
}