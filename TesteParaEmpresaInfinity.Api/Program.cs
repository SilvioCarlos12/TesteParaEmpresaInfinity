using Microsoft.EntityFrameworkCore;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;
using TesteParaEmpresaInfinity.Aplicacao;
using TesteParaEmpresaInfinity.Infra;
using Refit;
using TesteParaEmpresaInfinity.Infra.RepositorioApi;
using TesteParaEmpresaInfinity.Api.RotasExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<UsuarioContext>(options => options.UseNpgsql("name=ConnectionStrings:BancoDeDados",
                                                                 b => b.MigrationsAssembly("TesteParaEmpresaInfinity.Infra")));

builder.Services.AddRefitClient<IPlaceHolderApi>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["PlaceHolderConfiguracao:UrlBase"]);

});

builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioPlaceHolderService, UsuarioPlaceHolderService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UsuarioContext>();
    context.Database.Migrate();
}
app.MapUsuario()
   .MapUsuarioExterno();
app.Run();
