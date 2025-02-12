using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TesteParaEmpresaInfinity.Domain;

namespace TesteParaEmpresaInfinity.Infra
{
    public sealed class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuarioContext _context;

        public UsuarioRepositorio(UsuarioContext context)
        {
            _context = context;
        }

        public async Task Deletar(Usuario usuario, CancellationToken cancellation)
        {
            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<List<Usuario>> ObterTodosUsuarios(CancellationToken cancellation)
        {
            return await _context.Usuarios.ToListAsync(cancellation);
        }

        public async Task<List<Usuario>> ObterUsuarioPorFiltro(Expression<Func<Usuario, bool>> filter, CancellationToken cancellation)
        {
           return await _context.Usuarios.AsNoTracking().Where(filter).ToListAsync(cancellation);
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id, CancellationToken cancellation)
        {
            return await _context.Usuarios.SingleAsync(x => x.Id.Equals(id), cancellation);
        }

        public async Task Inserir(Usuario usuario, CancellationToken cancellation)
        {
           await _context.Usuarios.AddAsync(usuario, cancellation);

           await _context.SaveChangesAsync(cancellation);
        }

        public async Task Atualizar(Usuario usuario, CancellationToken cancellation)
        {

            _context.Usuarios.Update(usuario);

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
