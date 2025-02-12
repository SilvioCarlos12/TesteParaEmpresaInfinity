using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;

namespace TesteParaEmpresaInfinity.Aplicacao.Results
{
    public class Resultado<T>
    {
        public T? Resposta { get; private set; }
        public List<ErroDto> Erros { get; private set; } = new List<ErroDto>();

        public bool ExisteErro => Erros.Count > 0;

        public HttpStatusCode StatusCode { get; private set; }

        public Resultado(T resposta, HttpStatusCode StatusCode)
        {
            Resposta = resposta;
        }

        public Resultado(HttpStatusCode statusCode, params ErroDto[] erro)
        {
            Erros.AddRange(erro);
            StatusCode = statusCode;
        }

        public Resultado(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public class Resultado
    {
        public List<ErroDto> Erros { get; private set; } = new List<ErroDto>();

        public bool ExisteErro => Erros.Count > 0;

        public HttpStatusCode StatusCode { get; private set; }

        public Resultado(HttpStatusCode statusCode, params ErroDto[] erro)
        {
            Erros.AddRange(erro);
            StatusCode = statusCode;
        }

        public Resultado(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
