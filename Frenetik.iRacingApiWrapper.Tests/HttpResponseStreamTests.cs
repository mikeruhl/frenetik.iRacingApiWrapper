using System.Net;
using System.Text;

namespace Frenetik.iRacingApiWrapper.Tests;

public class HttpResponseStreamTests
{
    [Fact]
    public async Task Read_ReadsFromUnderlyingStream()
    {
        // Arrange
        var testData = "test,data,stream\n1,2,3"u8.ToArray();
        var memoryStream = new MemoryStream(testData);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        var buffer = new byte[testData.Length];
        var bytesRead = await httpResponseStream.ReadAsync(buffer, 0, buffer.Length);

        // Assert
        Assert.Equal(testData.Length, bytesRead);
        Assert.Equal(testData, buffer);
    }

    [Fact]
    public async Task ReadAsync_WithMemory_ReadsFromUnderlyingStream()
    {
        // Arrange
        var testData = "csv,header\nvalue1,value2"u8.ToArray();
        var memoryStream = new MemoryStream(testData);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        var buffer = new byte[testData.Length];
        var bytesRead = await httpResponseStream.ReadAsync(buffer.AsMemory());

        // Assert
        Assert.Equal(testData.Length, bytesRead);
        Assert.Equal(testData, buffer);
    }

    [Fact]
    public async Task CanRead_ReturnsTrue_WhenNotDisposed()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.True(httpResponseStream.CanRead);
    }

    [Fact]
    public async Task CanRead_ReturnsFalse_AfterDispose()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        await httpResponseStream.DisposeAsync();

        // Assert
        Assert.False(httpResponseStream.CanRead);
    }

    [Fact]
    public async Task CanSeek_ReturnsFalse()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.False(httpResponseStream.CanSeek);
    }

    [Fact]
    public async Task CanWrite_ReturnsFalse()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.False(httpResponseStream.CanWrite);
    }

    [Fact]
    public async Task Length_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => _ = httpResponseStream.Length);
    }

    [Fact]
    public async Task Position_Get_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => _ = httpResponseStream.Position);
    }

    [Fact]
    public async Task Position_Set_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => httpResponseStream.Position = 0);
    }

    [Fact]
    public async Task Seek_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => httpResponseStream.Seek(0, SeekOrigin.Begin));
    }

    [Fact]
    public async Task SetLength_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => httpResponseStream.SetLength(100));
    }

    [Fact]
    public async Task Write_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => httpResponseStream.Write(new byte[10], 0, 10));
    }

    [Fact]
    public async Task Flush_ThrowsNotSupportedException()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => httpResponseStream.Flush());
    }

    [Fact]
    public void Dispose_DisposesInnerStreamAndResponse()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
#pragma warning disable xUnit1031 // Do not use blocking task operations in test method
        var contentStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
#pragma warning restore xUnit1031 // Do not use blocking task operations in test method
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        httpResponseStream.Dispose();

        // Assert
        Assert.False(httpResponseStream.CanRead);
        Assert.Throws<ObjectDisposedException>(() => contentStream.ReadByte());
    }

    [Fact]
    public async Task DisposeAsync_DisposesInnerStreamAndResponse()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        await httpResponseStream.DisposeAsync();

        // Assert
        Assert.False(httpResponseStream.CanRead);
        Assert.Throws<ObjectDisposedException>(() => contentStream.ReadByte());
    }

    [Fact]
    public async Task Constructor_ThrowsArgumentNullException_WhenInnerStreamIsNull()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.OK);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new HttpResponseStream(null!, response));
    }

    [Fact]
    public async Task Constructor_ThrowsArgumentNullException_WhenResponseIsNull()
    {
        // Arrange
        var memoryStream = new MemoryStream();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new HttpResponseStream(memoryStream, null!));
    }

    [Fact]
    public async Task StreamReader_CanReadCsvData()
    {
        // Arrange
        var csvData = "header1,header2,header3\nvalue1,value2,value3\nvalue4,value5,value6";
        var testData = Encoding.UTF8.GetBytes(csvData);
        var memoryStream = new MemoryStream(testData);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        using var reader = new StreamReader(httpResponseStream);
        var header = await reader.ReadLineAsync();
        var line1 = await reader.ReadLineAsync();
        var line2 = await reader.ReadLineAsync();

        // Assert
        Assert.Equal("header1,header2,header3", header);
        Assert.Equal("value1,value2,value3", line1);
        Assert.Equal("value4,value5,value6", line2);
    }

    [Fact]
    public async Task MultipleReads_AdvanceStreamPosition()
    {
        // Arrange
        var testData = "0123456789"u8.ToArray();
        var memoryStream = new MemoryStream(testData);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(memoryStream)
        };
        var contentStream = await response.Content.ReadAsStreamAsync();
        var httpResponseStream = new HttpResponseStream(contentStream, response);

        // Act
        var buffer1 = new byte[3];
        var buffer2 = new byte[4];
        var buffer3 = new byte[3];

        var read1 = await httpResponseStream.ReadAsync(buffer1, 0, 3);
        var read2 = await httpResponseStream.ReadAsync(buffer2, 0, 4);
        var read3 = await httpResponseStream.ReadAsync(buffer3, 0, 3);

        // Assert
        Assert.Equal(3, read1);
        Assert.Equal(4, read2);
        Assert.Equal(3, read3);
        Assert.Equal("012"u8.ToArray(), buffer1);
        Assert.Equal("3456"u8.ToArray(), buffer2);
        Assert.Equal("789"u8.ToArray(), buffer3);
    }
}
