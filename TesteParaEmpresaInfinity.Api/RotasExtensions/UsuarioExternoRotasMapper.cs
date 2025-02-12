using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;

namespace TesteParaEmpresaInfinity.Api.RotasExtensions
{
    public static class UsuarioExternoRotasMapper
    {
        public static WebApplication MapUsuarioExterno(this WebApplication app) => app
            .MapBuscarUsuarioExterno();

        private static WebApplication MapBuscarUsuarioExterno(this WebApplication app)
        {
            app.MapGet("usuario-externo/{{id}}",
                async ([FromServices] IUsuarioPlaceHolderService usuarioPlaceHolderService, int id, CancellationToken cancellationToken) =>
                {

                    var response = await usuarioPlaceHolderService.ObterUsuarioPlaceHolderPorId(id);


                    return response.StatusCode switch
                    {
                        HttpStatusCode.OK => Results.Ok(response.Resposta),
                        HttpStatusCode.NotFound => Results.NotFound(),
                        HttpStatusCode.InternalServerError => Results.Problem(),
                        _ => throw new ArgumentOutOfRangeException(nameof(response))
                    };
                })
                .Produces(200)
                .Produces(404)
                .Produces(500, typeof(ErroDto))
                .WithMetadata(new SwaggerOperationAttribute("Buscar um usuário externo", "Busca um usuário da api do placeHolder"))
                .WithTags("UsuárioExterno");

            return app;
        }
    }
}
