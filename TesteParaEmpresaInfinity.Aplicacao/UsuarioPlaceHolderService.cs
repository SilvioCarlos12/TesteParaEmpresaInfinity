using Refit;
using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;
using TesteParaEmpresaInfinity.Aplicacao.Mappers;
using TesteParaEmpresaInfinity.Aplicacao.Results;
using TesteParaEmpresaInfinity.Infra.RepositorioApi;

namespace TesteParaEmpresaInfinity.Aplicacao
{
    public class UsuarioPlaceHolderService : IUsuarioPlaceHolderService
    {
        private readonly IPlaceHolderApi _placeHolderApi;

        public UsuarioPlaceHolderService(IPlaceHolderApi placeHolderApi)
        {
            _placeHolderApi = placeHolderApi;
        }

        public async Task<Resultado<UsuarioPlaceHolderDto>> ObterUsuarioPlaceHolderPorId(int id)
        {
            try
            {
                var usuarioPlaceHolder = await _placeHolderApi.GetUsuarioPlaceHolderById(id);

                return new Resultado<UsuarioPlaceHolderDto>(usuarioPlaceHolder.ToUsuarioPlaceHolderDto(), HttpStatusCode.OK);

            }
            catch (ApiException ex)
            {

                return new Resultado<UsuarioPlaceHolderDto>(ex.StatusCode, new ErroDto(ex.StatusCode.ToString(), ex.Content ?? string.Empty));
            }
        }
    }
}
