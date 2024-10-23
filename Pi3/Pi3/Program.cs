using Microsoft.Extensions.Options;
using Pi3.Filter;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Repositories.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ContextMongodb>();
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();

ContextMongodb.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
ContextMongodb.DatabaseName = builder.Configuration.GetSection("MongoConnection:Database").Value;

ContextMongodb.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSSL").Value);


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
