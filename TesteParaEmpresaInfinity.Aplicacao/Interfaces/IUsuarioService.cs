using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Results;

namespace TesteParaEmpresaInfinity.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task<Resultado> InserirUsuario(UsuarioDto usuario, CancellationToken cancellationToken);
        Task<Resultado> DeleteUsuario(Guid id, CancellationToken cancellationToken);
        Task<Resultado<UsuarioDto>> ObterUsuarioPorId(Guid id, CancellationToken cancellationToken);
        Task<Resultado<List<UsuarioDto>>> ObterUsuarioPorFiltro(string nome, string email, string telefone, CancellationToken cancellationToken);
        Task<Resultado> AtualizarUsuario(Guid id, UsuarioDto usuarioDto, CancellationToken cancellationToken);
    }
}
