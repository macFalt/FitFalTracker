using FitFalTracker.Application;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
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
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler(appErr =>
{
    appErr.Run(async context =>
    {
        var feature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        var ex = feature?.Error;

        if (ex is FitFalTracker.Domain.Exceptions.NotFoundException nf)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title  = "Not Found",
                Detail = nf.Message
            });
            return;
        }

        // fallback 500
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title  = "Unexpected error"
        });
    });
});


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



