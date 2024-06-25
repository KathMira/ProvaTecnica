using GeradorNumerosTelefone.Modelos;
using System.Text.Json;

namespace GeradorNumerosTelefone;

public class Servico
{
    public List<SiglaDdds> DeserializarDddsJson()
    {
        //Ler o arquivo de json e trazer as informações numa lista
        StreamReader r = new StreamReader("../../../dddsPorEstado.json");
        string json = r.ReadToEnd();
        var dddsPorEstado = JsonSerializer.Deserialize<List<SiglaDdds>>(json);
        return dddsPorEstado!;
    }

    public bool ValidaUf(string ufInformada)
    {
        var dddsPorEstado = DeserializarDddsJson();
        foreach (var ufs in dddsPorEstado)
        {
            if (ufs.Sigla.Equals(ufInformada.ToUpper()))
                return true;
        }
        return false;
    }
    public string RetornaDddAleatorioUf(string ufInformada)
    {
        var dddsPorEstado = DeserializarDddsJson();
        foreach(var ufs in dddsPorEstado)
        {
            if(ufs.Sigla.Equals(ufInformada.ToUpper()))
            {
                Random random = new Random();
                return ufs.Ddds[random.Next(0, ufs.Ddds.Count -1)];
            }
        }
        return string.Empty;
    }

    public string RetornaDddAleatorioComUfAleatorio()
    {
        var dddsPorEstado = DeserializarDddsJson();
        Random random = new Random();
        var indiceUfs = random.Next(0, dddsPorEstado.Count - 1);
        var indiceDdds = random.Next(0, dddsPorEstado[indiceUfs].Ddds.Count -1);
        return dddsPorEstado[indiceUfs].Ddds[indiceDdds];
    }
}


