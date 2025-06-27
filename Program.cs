using Microsoft.EntityFrameworkCore;
using EComunidadeAPI.Data;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 
app.UseHttpsRedirection();
 
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
 
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
 
app.UseAuthorization();        
app.MapControllers();  
app.Run();
 
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}