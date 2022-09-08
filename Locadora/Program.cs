using Locadora.Application.ExtensionsApplication;
using Locadora.Data.ExtensionsData;
using Locadora.ExtensionsPresentation;
using Locadora.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSingleton<Token>();
builder.Services.AddAplication();
builder.Services.AddData(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
