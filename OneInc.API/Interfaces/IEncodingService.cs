namespace OneInc.API.Interfaces;

public interface IEncodingService
{
     IAsyncEnumerable<char> EncodeAsync(string value, CancellationToken cancellationToken);
}