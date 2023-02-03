using OneInc.API.Interfaces;

namespace OneInc.API.Services;

public class OneIncEncodingService : IEncodingService
{
    private readonly IDelayableCollection<char> _delayer;
    private readonly IStringEncoder _encoder;

    public OneIncEncodingService(IDelayableCollection<char> delayer, IStringEncoder encoder)
    {
        _delayer = delayer;
        _encoder = encoder;
    }

    public IAsyncEnumerable<char> EncodeAsync(string value, CancellationToken cancellationToken)
    {
        var encoded = _encoder.Encode(value);
        var collection = encoded.ToCharArray().AsEnumerable();
        return _delayer.DelayAsync(collection, cancellationToken);
    }

}