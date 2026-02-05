var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapPost("/encrypt", (string text, int shift) =>
{
    var encrypted = Caesar(text, shift);
    return Results.Ok(new { input = text, shift, output = encrypted });
});


app.MapPost("/decrypt", (string text, int shift) =>
{
    var decrypted = Caesar(text, -shift);
    return Results.Ok(new { input = text, shift, output = decrypted });
});


static string Caesar(string input, int shift)
{
    if (string.IsNullOrEmpty(input)) return input;

    shift = shift % 26; // håller shift inom alfabetet

    char ShiftChar(char c, char a)
    {
        int offset = c - a;
        int shifted = (offset + shift + 26) % 26;
        return (char)(a + shifted);
    }

    var chars = input.ToCharArray();

    for (int i = 0; i < chars.Length; i++)
    {
        char c = chars[i];

        if (c >= 'a' && c <= 'z') chars[i] = ShiftChar(c, 'a');
        else if (c >= 'A' && c <= 'Z') chars[i] = ShiftChar(c, 'A');
        // annars lämnar vi tecknet som det är
    }

    return new string(chars);
}


app.Run();
