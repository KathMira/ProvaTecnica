using System;
using System.Collections.Generic;

namespace GeradorNumerosTelefone
{
    public class GeradorTelefoneBrasil
    {
        public static UFsBrasil[] RegiaoCentroOeste = new UFsBrasil[] { UFsBrasil.DF, UFsBrasil.GO, UFsBrasil.MT, UFsBrasil.MS };

        public static UFsBrasil[] RegiaoNordeste = new UFsBrasil[] { UFsBrasil.AL, UFsBrasil.BA, 
            UFsBrasil.CE, UFsBrasil.MA, UFsBrasil.PB, UFsBrasil.PE, UFsBrasil.PI, UFsBrasil.RN, UFsBrasil.SE };

        public static UFsBrasil[] RegiaoNorte = new UFsBrasil[] { UFsBrasil.AC, UFsBrasil.AP, 
            UFsBrasil.AM, UFsBrasil.PA, UFsBrasil.RO, UFsBrasil.RR, UFsBrasil.TO };

        public static UFsBrasil[] RegiaoSudeste = new UFsBrasil[] { UFsBrasil.ES, UFsBrasil.MG, UFsBrasil.RJ, UFsBrasil.SP };
        public static UFsBrasil[] RegiaoSul = new UFsBrasil[] { UFsBrasil.PR, UFsBrasil.RS, UFsBrasil.SC };

        public string GerarNumero(TipoServicoTelefone? tipoServico = null, params UFsBrasil[] uf)
        {
            var DddsPorEstado = Dicionario();

            Console.WriteLine("\nQual o tipo de número que você deseja gerar o número?");
            Console.WriteLine("\nFixo   (1)");
            Console.WriteLine("Móvel    (2)");

            switch (opcoes)
            {
                case '1':
                    break;

                case '2':
                    break;
            }

            Random rnd = new Random();
            var num = rnd.Next(1000, 9999).ToString();
            var num2 = rnd.Next(1000, 9999).ToString();
            Console.WriteLine($"9{num}-{num2}");

            return string.Empty;
        }
        Dictionary<string, List<string>> Dicionario()
        {

            return new Dictionary<string, List<string>>
            {
            {"AC", new List<string> { "68" }},
            {"AL", new List<string> { "82" }},
            {"AP", new List<string> { "96" }},
            {"AM", new List<string> { "92", "97" }},
            {"BA", new List<string> { "71", "73", "74", "75", "77" }},
            {"CE", new List<string> { "85", "88" }},
            {"DF", new List<string> { "61" }},
            {"ES", new List<string> { "27", "28" }},
            {"GO", new List<string> { "62", "64" }},
            {"MA", new List<string> { "98", "99" }},
            {"MT", new List<string> { "65", "66" }},
            {"MS", new List<string> { "67" }},
            {"MG", new List<string> { "31", "32", "33", "34", "35", "37", "38" }},
            {"PA", new List<string> { "91", "93", "94" }},
            {"PB", new List<string> { "83" }},
            {"PR", new List<string> { "41", "42", "43", "44", "45", "46" }},
            {"PE", new List<string> { "81", "87" }},
            {"PI", new List<string> { "86", "89" }},
            {"RJ", new List<string> { "21", "22", "24" }},
            {"RN", new List<string> { "84" }},
            {"RS", new List<string> { "51", "53", "54", "55" }},
            {"RO", new List<string> { "69" }},
            {"RR", new List<string> { "95" }},
            {"SC", new List<string> { "47", "48", "49" }},
            {"SP", new List<string> { "11", "12", "13", "14", "15", "16", "17", "18", "19" }},
            {"SE", new List<string> { "79" }},
            {"TO", new List<string> { "63" }}
        };
        }

    }

    public enum TipoServicoTelefone
    {
        FixoComutado,
        MovelPessoal
    }

    public enum UFsBrasil
    {
        AC, 
        AL, 
        AP, 
        AM, 
        BA, 
        CE, 
        DF, 
        ES, 
        GO, 
        MA, 
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO
    }
}
