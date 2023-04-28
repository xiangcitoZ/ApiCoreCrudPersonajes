using ApiCoreCrudPersonajes.Data;
using ApiCoreCrudPersonajes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString =
    builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api CRUD personajes",
        Description = "CRUD",
        Version = "v1"
    });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json"
        , name: "Api CRUD PERSONAJES");
    options.RoutePrefix = "";
});


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
  
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
