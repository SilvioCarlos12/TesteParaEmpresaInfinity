using Refit;
using TesteParaEmpresaInfinity.Infra.RepositorioApi.Dtos;

namespace TesteParaEmpresaInfinity.Infra.RepositorioApi
{
    public interface IPlaceHolderApi
    {
        [Get("/todos/{id}")]
        Task<DadosUsuariosPlaceHolderDto> GetUsuarioPlaceHolderById(int id);
    }
}
