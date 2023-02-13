using System.Runtime.CompilerServices;
using OneInc.API.Interfaces;

namespace OneInc.API.Services;

public class RandomTimeCollectionDelayer<T> : IDelayableCollection<T>
{
    private readonly Random _randomizer = new();

    public async IAsyncEnumerable<T> DelayAsync(IEnumerable<T> collection, [EnumeratorCancellation] CancellationToken cancellationToken,
        int delayTimeInSeconds = 5)
    {
        foreach (var charItem in collection)
        {
            cancellationToken.ThrowIfCancellationRequested();
            int delayTimeInMilliseconds = _randomizer.Next(1, delayTimeInSeconds) * 1000;
            await Task.Delay(delayTimeInMilliseconds, cancellationToken);
            yield return charItem;
        }
    }
}