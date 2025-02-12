using System.Net.Mail;
using TesteParaEmpresaInfinity.Aplicacao.Dtos;
using TesteParaEmpresaInfinity.Aplicacao.MensagensErros;

namespace TesteParaEmpresaInfinity.Aplicacao.Validacoes
{
    public static class UsarioDtoValidacaoExtensao
    {
        public static List<ErroDto> Validacao(this UsuarioDto usuarioDto)
        {
            var erros = new List<ErroDto>();

            if (string.IsNullOrEmpty(usuarioDto.Telefone))
            {
                erros.Add(new ErroDto(CodigoErro.TelefoneObrigatorio, MensagemErro.TelefoneObrigatorio));
            }

            if (string.IsNullOrEmpty(usuarioDto.Email))
            {
                erros.Add(new ErroDto(CodigoErro.EmailObrigatorio, MensagemErro.EmailObrigatorio));
            }

            if (string.IsNullOrEmpty(usuarioDto.Nome))
            {
                erros.Add(new ErroDto(CodigoErro.NomeObrigatorio, MensagemErro.NomeObrigatorio));
            }

            if (TelefoneEstarInvalido(usuarioDto.Telefone ?? string.Empty))
            {
                erros.Add(new ErroDto(CodigoErro.TelefoneInvalido, MensagemErro.TelefoneInvalido));
            }

            if (EmailEstarInvalido(usuarioDto.Email ?? string.Empty))
            {
                erros.Add(new ErroDto(CodigoErro.EmailInvalido, MensagemErro.EmailInvalido));
            }


            return erros;
        }

        private static bool EmailEstarInvalido(string email)
        {
            try
            {
                var resultado = new MailAddress(email);

                return false;
            }
            catch(ArgumentException)
            {
                return true;
            }
            catch (FormatException)
            {

                return true;
            }
        }
        private static bool TelefoneEstarInvalido(string telefone)
        {
            var telefoneValido = long.TryParse(telefone, out var resultado) && telefone.Length == 12;

            if (telefoneValido)
            {
                return false;
            }

            return true;
        }
    }
}
