using Microsoft.EntityFrameworkCore;
using TesteParaEmpresaInfinity.Domain;

namespace TesteParaEmpresaInfinity.Infra
{
    public sealed class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
