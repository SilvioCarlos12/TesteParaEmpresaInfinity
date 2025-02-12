namespace TesteParaEmpresaInfinity.Aplicacao.Dtos
{
    public sealed record UsuarioSaidaDto(Guid Id, string Nome, string Telefone, string Email) : UsuarioDto(Nome, Telefone, Email);
}
