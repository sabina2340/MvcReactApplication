using ApplicationMVC1.Server.Data;
using ApplicationMVC1.Server.Services.Interfaces;
using ApplicationMVC1.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDataContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=test2;User Id=postgres;Password=12345;");
});

builder.Services.AddScoped<ITgroupService, TgroupService>();
builder.Services.AddScoped<ITpropertyService, TpropertyService>();
builder.Services.AddScoped<ITrelationService, TrelationService>();
builder.Services.AddScoped<ITreeNodeService, TreeNodeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();