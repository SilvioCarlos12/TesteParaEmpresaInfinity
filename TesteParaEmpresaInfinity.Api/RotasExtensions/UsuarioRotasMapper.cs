using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;

namespace TesteParaEmpresaInfinity.Api.RotasExtensions
{
    public static class UsuarioRotasMapper
    {
        public static WebApplication MapUsuario(this WebApplication app) => app
                 .MapCriarUsuario();
        private static WebApplication MapCriarUsuario(this WebApplication app)
        {
            app.MapPost("/usuario",
                async ([FromServices] IUsuarioService usarioService, UsuarioDto usuarioDto, CancellationToken cancellationToken) =>
                {

                    var response = await usarioService.InserirUsuario(usuarioDto, cancellationToken);


                    return response.StatusCode switch
                    {
                        HttpStatusCode.Created => Results.Created("", ""),
                        HttpStatusCode.InternalServerError => Results.Problem(),
                        _ => throw new ArgumentOutOfRangeException(nameof(response))
                    };
                })
                .Produces(201)
                .Produces(400, typeof(ErroDto))
                .Produces(500, typeof(ErroDto))
                .WithMetadata(new SwaggerOperationAttribute("Criar Usuário", "Cria um usuário"))
                .WithTags("Usuário");

            return app;
        }
    }
}
