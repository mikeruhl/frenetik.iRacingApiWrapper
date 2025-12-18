using System.Security.Cryptography;
using System.Text;

namespace Frenetik.iRacingApiWrapper.Tests;

public class SecretMaskingTests
{
    [Fact]
    public void MaskSecret_ProducesConsistentOutput()
    {
        // Arrange
        var secret = "my-secret-value";
        var identifier = "my-identifier";

        // Act
        var hash1 = MaskSecret(secret, identifier);
        var hash2 = MaskSecret(secret, identifier);

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void MaskSecret_NormalizesIdentifier()
    {
        // Arrange
        var secret = "my-secret";

        // Act
        var hash1 = MaskSecret(secret, "TestUser");
        var hash2 = MaskSecret(secret, "testuser");
        var hash3 = MaskSecret(secret, "  testuser  ");

        // Assert
        Assert.Equal(hash1, hash2);
        Assert.Equal(hash2, hash3);
    }

    [Fact]
    public void MaskSecret_ProducesDifferentHashForDifferentSecrets()
    {
        // Arrange
        var identifier = "same-identifier";

        // Act
        var hash1 = MaskSecret("secret1", identifier);
        var hash2 = MaskSecret("secret2", identifier);

        // Assert
        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void MaskSecret_ProducesDifferentHashForDifferentIdentifiers()
    {
        // Arrange
        var secret = "same-secret";

        // Act
        var hash1 = MaskSecret(secret, "identifier1");
        var hash2 = MaskSecret(secret, "identifier2");

        // Assert
        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void MaskSecret_ProducesBase64EncodedSHA256Hash()
    {
        // Arrange
        var secret = "test-secret";
        var identifier = "test-id";

        // Act
        var result = MaskSecret(secret, identifier);

        // Assert
        // SHA256 hash is 32 bytes, Base64 encoded is 44 characters (with potential padding)
        Assert.NotEmpty(result);
        Assert.Matches(@"^[A-Za-z0-9+/]+=*$", result); // Valid Base64 pattern

        // Verify it's a valid Base64 string by attempting to decode it
        var bytes = Convert.FromBase64String(result);
        Assert.Equal(32, bytes.Length); // SHA256 produces 32 bytes
    }

    [Theory]
    [InlineData("password123", "user@email.com")]
    [InlineData("CLIENT-SECRET-ABC", "client-id-123")]
    [InlineData("", "identifier")]
    [InlineData("secret", "")]
    public void MaskSecret_HandlesVariousInputs(string secret, string identifier)
    {
        // Act
        var result = MaskSecret(secret, identifier);

        // Assert
        Assert.NotEmpty(result);
        var bytes = Convert.FromBase64String(result);
        Assert.Equal(32, bytes.Length);
    }

    [Fact]
    public void MaskSecret_MatchesExpectedAlgorithm()
    {
        // Arrange
        var secret = "my-password";
        var identifier = "MyUsername";
        var normalizedId = identifier.Trim().ToLowerInvariant();
        var combined = $"{secret}{normalizedId}";

        // Act
        var result = MaskSecret(secret, identifier);

        // Calculate expected hash manually
        var bytes = Encoding.UTF8.GetBytes(combined);
        var hash = SHA256.HashData(bytes);
        var expected = Convert.ToBase64String(hash);

        // Assert
        Assert.Equal(expected, result);
    }

    // Helper method that replicates the MaskSecret algorithm from PasswordLimitedTokenProvider
    private static string MaskSecret(string secret, string identifier)
    {
        var normalizedId = identifier.Trim().ToLowerInvariant();
        var combined = $"{secret}{normalizedId}";
        var bytes = Encoding.UTF8.GetBytes(combined);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
