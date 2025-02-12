using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Results;

namespace TesteParaEmpresaInfinity.Aplicacao.Interfaces
{
    public interface IUsuarioPlaceHolderService
    {
        Task<Resultado<UsuarioPlaceHolderDto>> ObterUsuarioPlaceHolderPorId(int id);
    }
}
