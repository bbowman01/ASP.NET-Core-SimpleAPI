using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (if needed).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/// <summary>
/// Represents a weather forecast.
/// </summary>
internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Gets the date of the weather forecast.
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Gets the temperature in Celsius.
    /// </summary>
    public int TemperatureC { get; init; }

    /// <summary>
    /// Gets the temperature in Fahrenheit.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Gets the summary of the weather forecast.
    /// </summary>
    public string? Summary { get; init; }
}

app.MapGet("/weatherforecast", () =>
{
    /// <summary>
    /// Retrieves the weather forecast.
    /// </summary>
    var forecast = new WeatherForecast
    (
        DateTime.Now,
        Random.Shared.Next(-20, 55),
        "Some summary"
    );
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

app.MapGet("/", () => "Hello from the minimal API!");
