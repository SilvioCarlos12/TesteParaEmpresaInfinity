using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Results;

namespace TesteParaEmpresaInfinity.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task<Resultado> InserirUsuario(UsuarioDto usuario, CancellationToken cancellationToken);
        Task<Resultado> DeleteUsuario(Guid id, CancellationToken cancellationToken);
        Task<Resultado<UsuarioSaidaDto>> ObterUsuarioPorId(Guid id, CancellationToken cancellationToken);
        Task<Resultado<List<UsuarioSaidaDto>>> ObterUsuarioPorFiltro(UsuarioDto usuarioDto, CancellationToken cancellationToken);
        Task<Resultado> AtualizarUsuario(Guid id, UsuarioDto usuarioDto, CancellationToken cancellationToken);
    }
}
