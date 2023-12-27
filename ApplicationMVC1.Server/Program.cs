using ApplicationMVC1.Server.Services.Interfaces;
using ApplicationMVC1.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApplicationMVC1.Server.Repository;
using ApplicationMVC1.Server.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDataContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=test2;User Id=postgres;Password=sabinamini04;");
});

builder.Services.AddScoped<ITgroupService, TgroupService>();
builder.Services.AddScoped<ITpropertyService, TpropertyService>();
builder.Services.AddScoped<ITrelationService, TrelationService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<ITreeRepository, TreeRepository>();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:5173") 
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();