using System.Text.Json.Serialization;

namespace ConsultaEndereco.Classes;

internal class Uf
{
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("sigla")]
    public string? Sigla { get; set; }
}
