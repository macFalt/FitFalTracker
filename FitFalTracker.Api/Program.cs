using FitFalTracker.Application;
using FitFalTracker.Persistance;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", 
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();
app.MapControllers();

app.MapFallback(() => Results.Text("Brak dopasowania"));


app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

//przed run
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
//
// app.MapGet("/weatherforecast", () =>
//     {
//         var forecast = Enumerable.Range(1, 5).Select(index =>
//                 new WeatherForecast
//                 (
//                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                     Random.Shared.Next(-20, 55),
//                     summaries[Random.Shared.Next(summaries.Length)]
//                 ))
//             .ToArray();
//         return forecast;
//     })
//     .WithName("GetWeatherForecast")
//     .WithOpenApi();


