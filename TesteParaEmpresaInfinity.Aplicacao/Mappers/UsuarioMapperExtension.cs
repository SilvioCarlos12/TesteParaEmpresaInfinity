using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Domain;
using TesteParaEmpresaInfinity.Infra.RepositorioApi.Dtos;

namespace TesteParaEmpresaInfinity.Aplicacao.Mappers
{
    public static class UsuarioMapperExtension
    {
        public static Usuario ToEntidade (this UsuarioDto dto)
        {
            return new Usuario
            {
                Email = dto.Email,
                Nome = dto.Nome,
                Telefone = dto.Telefone
            };
        }

        public static UsuarioDto ToDto(this Usuario usuario)
        {
            return new UsuarioDto(usuario.Nome, usuario.Telefone, usuario.Email);
        }

        public static UsuarioPlaceHolderDto ToUsuarioPlaceHolderDto(this DadosUsuariosPlaceHolderDto usuarioPlaceHolder)
        {
            return new UsuarioPlaceHolderDto(usuarioPlaceHolder.UserId, usuarioPlaceHolder.Id, usuarioPlaceHolder.Title, usuarioPlaceHolder.Completed);
        }

    }
}
