using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello");
app.MapPost("/login", (Minimal_API.LoginDTO loginDTO) => {
    if (loginDTO.Email == "adm@test.com" && loginDTO.Senha == "123456")
        return Results.Ok("Sucesso");
    else 
        return Results.Unauthorized();
});
app.Run("http://localhost:5024");

public delegate void MeuDelegate(int param1, string param2);

public partial class Program
{
    public static void Main()
    {
        MeuDelegate meuDelegate = MeuMetodo;
        meuDelegate(10, "teste");
    }

    public static void MeuMetodo(int param1, string param2)
    {
        Console.WriteLine($"param1: {param1}, param2: {param2}");
    }
}







// using System;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.MapGet("/", () => "Hello");
// app.MapPost("/login", (LoginDTO loginDTO) => {
//     if (loginDTO.Email == "adm@test.com" && loginDTO.Senha == "123456")
//         return Results.Ok("Sucesso");
//     else 
//         return Results.Unauthorized();
// });
// app.Run("http://localhost:5024"); // Ensure no leading space

// public delegate void MeuDelegate(int param1, string param2);

// public partial class Program
// {
//     public static void Main()
//     {
//         MeuDelegate meuDelegate = MeuMetodo;
//         meuDelegate(10, "teste");
//     }

//     public static void MeuMetodo(int param1, string param2)
//     {
//         Console.WriteLine($"param1: {param1}, param2: {param2}");
//     }
// }

// public class LoginDTO
// {
//     public string Email { get; set; } = default!;
//     public string Senha { get; set; } = default!;
// }
