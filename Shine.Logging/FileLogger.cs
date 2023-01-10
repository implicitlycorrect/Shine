namespace Shine.Logging;

internal sealed class FileLogger : ILogger, IDisposable
{
    private readonly StreamWriter _writer;
    private readonly SemaphoreSlim _semaphore;
    public FileLogger(string filePath)
    {
        _writer = File.CreateText(filePath);
        _semaphore = new SemaphoreSlim(1);
    }

    public void Log(LogMessage message)
    {
        _semaphore.Wait();
        try
        {
            _writer.WriteLine(message.ToString());
        }
        finally
        {
            _writer.Flush();
            _semaphore.Release();
        }
    }

    public async Task LogAsync(LogMessage message)
    {
        await _semaphore.WaitAsync();
        try
        {
            await _writer.WriteLineAsync(message.ToString());
        }
        finally
        {
            await _writer.FlushAsync();
            _semaphore.Release();
        }
    }

    private bool _disposed;

    public void Dispose()
    {
        if (_disposed)
            return;

        _writer.Flush();
        _writer.BaseStream.Dispose();
        _writer.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    ~FileLogger()
    { 
        if (!_disposed)
        {
            Dispose();
            _disposed = true;
        }
    }
}
