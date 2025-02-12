using System.Net;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.Interfaces;
using TesteParaEmpresaInfinity.Aplicacao.Mappers;
using TesteParaEmpresaInfinity.Aplicacao.Results;
using TesteParaEmpresaInfinity.Infra;

namespace TesteParaEmpresaInfinity.Aplicacao
{
    public sealed class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Resultado> AtualizarUsuario(Guid id, UsuarioDto usuarioDto, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObterUsuarioPorId(id, cancellationToken);

                if (usuario == null)
                {

                    return new Resultado(HttpStatusCode.NotFound);
                }

                usuario.Telefone = usuarioDto.Telefone;

                usuario.Nome = usuarioDto.Nome;

                usuario.Email = usuarioDto.Email;

                await _usuarioRepositorio.Atualizar(usuario, cancellationToken);

                return new Resultado(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return new Resultado(HttpStatusCode.InternalServerError, new ErroDto("001", ex.Message));
            }
        }

        public async Task<Resultado> DeleteUsuario(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObterUsuarioPorId(id, cancellationToken);

                if (usuario == null)
                {

                    return new Resultado(HttpStatusCode.NotFound);
                }

                await _usuarioRepositorio.Deletar(usuario, cancellationToken);

                return new Resultado(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return new Resultado(HttpStatusCode.InternalServerError, new ErroDto("001", ex.Message));
            }
        }

        public async Task<Resultado> InserirUsuario(UsuarioDto usuario, CancellationToken cancellationToken)
        {
            try
            {

                await _usuarioRepositorio.Inserir(usuario.ToEntidade(), cancellationToken);

                return new Resultado(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new Resultado(HttpStatusCode.InternalServerError, new ErroDto("001", ex.Message));
            }
        }

        public async Task<Resultado<List<UsuarioDto>>> ObterUsuarioPorFiltro(string nome, string email, string telefone, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = await _usuarioRepositorio.ObterUsuarioPorFiltro(x => 
                (string.IsNullOrEmpty(telefone)|| x.Telefone == telefone) &&
                (string.IsNullOrEmpty(email) || x.Email == email) &&
                (string.IsNullOrEmpty(nome) || x.Nome == nome)
                , cancellationToken);

                return new Resultado<List<UsuarioDto>>(usuarios.Select(x => x.ToDto()).ToList(),HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return new Resultado<List<UsuarioDto>>(HttpStatusCode.InternalServerError, new ErroDto("001", ex.Message));
            }
        }

        public async Task<Resultado<UsuarioDto>> ObterUsuarioPorId(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObterUsuarioPorId(id, cancellationToken);

                if (usuario == null)
                {

                    return new Resultado<UsuarioDto>(HttpStatusCode.NotFound);
                }

                return new Resultado<UsuarioDto>(usuario.ToDto(), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new Resultado<UsuarioDto>(HttpStatusCode.InternalServerError, new ErroDto("001", ex.Message));
            }
        }
    }
}
