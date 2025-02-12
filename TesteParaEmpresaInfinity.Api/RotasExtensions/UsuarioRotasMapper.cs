using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;

namespace TesteParaEmpresaInfinity.Api.RotasExtensions
{
    public static class UsuarioRotasMapper
    {
        private const string _rotaRaizUsuario = "/usuario";
        public static WebApplication MapUsuario(this WebApplication app) => app
                 .MapCriarUsuario()
                 .MapObterUsuarioPorFiltro()
                 .MapDeletarUsuario()
                 .MapAtualizarUsuario()
                ;
        private static WebApplication MapCriarUsuario(this WebApplication app)
        {
            app.MapPost(_rotaRaizUsuario,
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

        private static WebApplication MapAtualizarUsuario(this WebApplication app)
        {
            app.MapPut($"{_rotaRaizUsuario}/{{id}}",
                async ([FromServices] IUsuarioService usarioService,Guid id ,UsuarioDto usuarioDto, CancellationToken cancellationToken) =>
                {

                    var response = await usarioService.AtualizarUsuario(id, usuarioDto, cancellationToken);


                    return response.StatusCode switch
                    {
                        HttpStatusCode.OK => Results.Ok(),
                        HttpStatusCode.NotFound => Results.NotFound(),
                        HttpStatusCode.InternalServerError => Results.Problem(),
                        _ => throw new ArgumentOutOfRangeException(nameof(response))
                    };
                })
                .Produces(200)
                .Produces(404)
                .Produces(500, typeof(ErroDto))
                .WithMetadata(new SwaggerOperationAttribute("Atualizar Usuário", "Atualiza um usuário"))
                .WithTags("Usuário");

            return app;
        }

        private static WebApplication MapObterUsuarioPorFiltro(this WebApplication app)
        {
            app.MapGet(_rotaRaizUsuario,
                async ([FromServices] IUsuarioService usarioService, [AsParameters] UsuarioDto usuarioDto, CancellationToken cancellationToken) =>
                {

                    var response = await usarioService.ObterUsuarioPorFiltro(usuarioDto, cancellationToken);


                    return response.StatusCode switch
                    {
                        HttpStatusCode.OK => Results.Ok(response.Resposta),
                        HttpStatusCode.InternalServerError => Results.Problem(),
                        _ => throw new ArgumentOutOfRangeException(nameof(response))
                    };
                })
                .Produces(200, typeof(List<UsuarioSaidaDto>))
                .Produces(400, typeof(ErroDto))
                .Produces(500, typeof(ErroDto))
                .WithMetadata(new SwaggerOperationAttribute("Buscar Usuário", "Buscar o usuário por filtro"))
                .WithTags("Usuário");

            return app;
        }

        private static WebApplication MapDeletarUsuario(this WebApplication app)
        {
            app.MapDelete($"{_rotaRaizUsuario}/{{id}}",
                async ([FromServices] IUsuarioService usarioService,Guid id, CancellationToken cancellationToken) =>
                {

                    var response = await usarioService.DeleteUsuario(id, cancellationToken);


                    return response.StatusCode switch
                    {
                        HttpStatusCode.NoContent => Results.NoContent(),
                        HttpStatusCode.NotFound => Results.NotFound(),
                        HttpStatusCode.InternalServerError => Results.Problem(),
                        _ => throw new ArgumentOutOfRangeException(nameof(response))
                    };
                })
                .Produces(204)
                .Produces(404)
                .Produces(500, typeof(ErroDto))
                .WithMetadata(new SwaggerOperationAttribute("Deletar Usuário", "Deleta um usuário"))
                .WithTags("Usuário");

            return app;
        }
    }
}
