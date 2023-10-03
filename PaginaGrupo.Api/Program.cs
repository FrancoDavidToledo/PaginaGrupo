using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;
using PaginaGrupo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();

//aca se agrega el "singleton" de dependencia injectada, es como el addtransient
builder.Services.AddScoped<INoticiasRepository, NoticiasRepository>();

//con esto se conecta a la bbdd
builder.Services.AddDbContext<PaginaGrupoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaginaGrupo"));

});


var app = builder.Build();



//var noticia = app.Services.GetServices<PaginaGrupo.Core.Interfaces.INoticiasRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
