using BLL.Services.Interfaces;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServiceTest, ServiceTest>();
builder.Services.AddScoped<IRepositoryTest, RepositoryTest>();

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

app.MapControllers();

app.Run();