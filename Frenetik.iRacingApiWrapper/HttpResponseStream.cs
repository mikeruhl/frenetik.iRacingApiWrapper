namespace Frenetik.iRacingApiWrapper;

/// <summary>
/// Wrapper stream that keeps the HttpResponseMessage alive and disposes it when the stream is disposed.
/// This enables true streaming for large responses without buffering the entire content in memory.
/// HTTP response streams are forward-only and do not support seeking or length operations.
/// </summary>
internal sealed class HttpResponseStream : Stream
{
    private readonly Stream _innerStream;
    private readonly HttpResponseMessage _response;
    private bool _disposed;

    public HttpResponseStream(Stream innerStream, HttpResponseMessage response)
    {
        _innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
        _response = response ?? throw new ArgumentNullException(nameof(response));
    }

    public override bool CanRead => !_disposed && _innerStream.CanRead;
    public override bool CanSeek => false; // HTTP response streams don't support seeking
    public override bool CanWrite => false; // HTTP response streams are read-only

    public override long Length => throw new NotSupportedException("HTTP response streams do not support length operations.");

    public override long Position
    {
        get => throw new NotSupportedException("HTTP response streams do not support position operations.");
        set => throw new NotSupportedException("HTTP response streams do not support position operations.");
    }

    public override void Flush() => throw new NotSupportedException("HTTP response streams are read-only.");

    public override int Read(byte[] buffer, int offset, int count) => _innerStream.Read(buffer, offset, count);

    public override long Seek(long offset, SeekOrigin origin)
        => throw new NotSupportedException("HTTP response streams do not support seeking.");

    public override void SetLength(long value)
        => throw new NotSupportedException("HTTP response streams do not support SetLength.");

    public override void Write(byte[] buffer, int offset, int count)
        => throw new NotSupportedException("HTTP response streams are read-only.");

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        => _innerStream.ReadAsync(buffer, offset, count, cancellationToken);

    public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        => _innerStream.ReadAsync(buffer, cancellationToken);

    protected override void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _innerStream.Dispose();
                _response.Dispose();
            }
            _disposed = true;
        }
        base.Dispose(disposing);
    }

    public override async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            await _innerStream.DisposeAsync();
            _response.Dispose();
            _disposed = true;
        }
        await base.DisposeAsync();
    }
}
