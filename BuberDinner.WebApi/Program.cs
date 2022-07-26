using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.WebApi.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddControllers(options =>
//    options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/api/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
