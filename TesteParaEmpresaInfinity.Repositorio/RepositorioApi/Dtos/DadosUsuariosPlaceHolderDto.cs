using Newtonsoft.Json;

namespace TesteParaEmpresaInfinity.Infra.RepositorioApi.Dtos
{
    public class DadosUsuariosPlaceHolderDto
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
