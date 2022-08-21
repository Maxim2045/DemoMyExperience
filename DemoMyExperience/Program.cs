using AutoMapper;
using DemoMyExperience.Configuration;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience.Models;
using DemoMyExperience.Interfaces;
using DemoMyExperience.Models;
using DemoMyExperience.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


//builder.Configuration.AddJsonFile("appsettings.json");



var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new AutoMapping());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DemoMyExperienceContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Demo");
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<ICrud<UserRepository>, UserService>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<DemoMyExperienceContext>();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
