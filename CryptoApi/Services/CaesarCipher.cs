namespace CryptoApi.Services;

public static class CaesarCipher
{
    public static string Encrypt(string text, int shift)
        => Transform(text, shift);

    public static string Decrypt(string text, int shift)
        => Transform(text, -shift);

    private static string Transform(string text, int shift)
    {
        if (string.IsNullOrEmpty(text)) return text;

        shift %= 26;

        char ShiftChar(char c, char a)
        {
            int offset = c - a;
            int shifted = (offset + shift + 26) % 26;
            return (char)(a + shifted);
        }

        var chars = text.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            var c = chars[i];

            if (char.IsLower(c)) chars[i] = ShiftChar(c, 'a');
            else if (char.IsUpper(c)) chars[i] = ShiftChar(c, 'A');
        
        }

        return new string(chars);
    }
}
