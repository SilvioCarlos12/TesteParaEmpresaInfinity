using TesteParaEmpresaInfinity.Aplicacao.Dtos;

namespace TesteParaEmpresaInfinity.Api.Extensao
{
    public static class ErroDtoExtensao
    {
        public static IResult ParaErrorDoTipoExcecao(this ErroDto erroDto)
        {
            return Results.Problem(detail: erroDto.Mensagem, statusCode: 500);
        }
    }
}
