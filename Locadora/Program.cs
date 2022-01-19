using Locadora.Application.Services;
using Locadora.Data;
using Locadora.Data.Repositories;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Interfaces.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Data
builder.Services.AddDbContext<LocadoraContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocadoraConnection")));
builder.Services.AddTransient<IDiretorRepository, DiretorRepository>();
builder.Services.AddTransient<IFilmeRepository, FilmeRepository>();
builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Application
builder.Services.AddTransient<IDiretorService, DiretorService>();
builder.Services.AddTransient<IFilmeService, FilmeService>();
builder.Services.AddTransient<IGeneroService, GeneroService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.BuildServiceProvider().GetService<LocadoraContext>().Database.Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
