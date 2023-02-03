using OneInc.API.Interfaces;

namespace OneInc.API.Services;

public class RandomCollectionDelayer<T> : IDelayableCollection<T>
{
    private readonly Random _randomizer = new();

    public async IAsyncEnumerable<T> DelayAsync(IEnumerable<T> collection, CancellationToken cancellationToken,
        int delayTimeInSeconds = 5)
    {
        foreach (var charItem in collection)
        {
            int delayTimeInMilliseconds = _randomizer.Next(1, delayTimeInSeconds) * 1000;
            await Task.Delay(delayTimeInMilliseconds, cancellationToken);
            yield return charItem;
        }
    }
}