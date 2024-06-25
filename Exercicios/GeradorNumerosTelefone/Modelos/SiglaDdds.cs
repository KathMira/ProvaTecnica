using System.Text.Json.Serialization;

namespace GeradorNumerosTelefone.Modelos;

public class SiglaDdds
{
    [JsonPropertyName("Sigla")]
    public string? Sigla { get; set; }

    [JsonPropertyName("Ddds")]
    public List<string>? Ddds { get; set; }
}

