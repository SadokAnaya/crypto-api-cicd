using Xunit;
using CryptoApi.Services;

namespace CryptoApi.Tests;

public class CaesarCipherTests
{
    [Fact]
    public void Encrypt_abc_shift3_returns_def()
    {
        // Arrange
        var input = "abc";
        var shift = 3;

        // Act
        var result = CaesarCipher.Encrypt(input, shift);

        // Assert
        Assert.Equal("def", result);
    }

    [Fact]
    public void Decrypt_def_shift3_returns_abc()
    {
        var input = "def";
        var shift = 3;

        var result = CaesarCipher.Decrypt(input, shift);

        Assert.Equal("abc", result);
    }

    [Fact]
    public void Encrypt_wraps_from_z_to_a()
    {
        var input = "xyz";
        var shift = 3;

        var result = CaesarCipher.Encrypt(input, shift);

        Assert.Equal("abc", result);
    }

    [Fact]
    public void Encrypt_preserves_case_and_non_letters()
    {
        var input = "Abc-XYZ!";
        var shift = 1;

        var result = CaesarCipher.Encrypt(input, shift);

        Assert.Equal("Bcd-YZA!", result);
    }

    [Fact]
    public void Encrypt_empty_string_returns_empty()
    {
        var input = "";
        var shift = 5;

        var result = CaesarCipher.Encrypt(input, shift);

        Assert.Equal("", result);
    }
}