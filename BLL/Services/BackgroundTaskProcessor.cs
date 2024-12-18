using System.Collections.Concurrent;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLL.Services;
public class BackgroundTaskProcessor : BackgroundService
{
    private readonly ILogger<BackgroundTaskProcessor> _logger;
    private readonly ConcurrentQueue<Func<Task>> _taskQueue = new();
    private readonly SemaphoreSlim _signal = new(0);

    public BackgroundTaskProcessor(ILogger<BackgroundTaskProcessor> logger)
    {
        _logger = logger;
    }

    public void EnqueueTask(Func<Task> task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        _taskQueue.Enqueue(task);
        _signal.Release();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background Task Processor started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            await _signal.WaitAsync(stoppingToken);

            if (_taskQueue.TryDequeue(out var task))
            {
                try
                {
                    await task();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred executing background task.");
                }
            }
        }

        _logger.LogInformation("Background Task Processor stopped.");
    }
}
