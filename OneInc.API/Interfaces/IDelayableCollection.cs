namespace OneInc.API.Interfaces;

public interface IDelayableCollection<T>
{
    IAsyncEnumerable<T> DelayAsync(IEnumerable<T> collection, CancellationToken cancellationToken,
        int delayTimeInSeconds = 5);

}