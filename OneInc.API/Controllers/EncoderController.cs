using System.Runtime.CompilerServices;
using System.Text;
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
    
    async IAsyncEnumerable<int> FetchItems()
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }
    
    async IAsyncEnumerable<string> FetchItemsChars(IEnumerable<char> word)
    { 
        foreach (char c in word)
        {
            await Task.Delay(1000);
            yield return c.ToString();
        }
    }
}