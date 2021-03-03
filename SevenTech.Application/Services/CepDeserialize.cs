using System.Text.Json.Serialization;

namespace SevenTech.Application.Services
{
    /// <summary>
    /// Objeto de deserialização do cep
    /// </summary>
    public class CepDeserialize
    {
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }
    }
}