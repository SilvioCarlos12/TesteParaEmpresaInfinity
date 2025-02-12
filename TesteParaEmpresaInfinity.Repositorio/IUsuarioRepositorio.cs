using System.Linq.Expressions;
using TesteParaEmpresaInfinity.Domain;

namespace TesteParaEmpresaInfinity.Infra
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObterUsuarioPorId(Guid id, CancellationToken cancellation);
        Task<List<Usuario>> ObterTodosUsuarios(CancellationToken cancellation);
        Task Atualizar(Usuario usuario, CancellationToken cancellation);
        Task Deletar(Usuario usuario, CancellationToken cancellation);
        Task Inserir(Usuario usuario, CancellationToken cancellation);
        Task<List<Usuario>> ObterUsuarioPorFiltro(Expression<Func<Usuario, bool>> filter, CancellationToken cancellation);
    }
}
