using BusinessLayer.Services.Autor;
using BusinessLayer.Services.Usuario;
using BusinessLayer.Services.Categoria;
using BusinessLayer.Services.Libro;

using DataLayer.Repositories.Autor;
using DataLayer.Repositories.Usuario;
using DataLayer.Repositories.Categoria;
using DataLayer.Repositories.Libro;

using DataLayer.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder
                                                        .AllowAnyOrigin()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(opcions =>
{
    opcions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    opcions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

//Autor
builder.Services.AddScoped<IAutorServices, AutorServices>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();

//Autor
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Categoria
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//Libro
builder.Services.AddScoped<ILibroServices, LibroServices>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

//Add Context
builder.Services.AddDbContext<Libreria2DbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
