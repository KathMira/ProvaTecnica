using GeradorNumerosTelefone;
using GeradorNumerosTelefone.Menus;
using GeradorNumerosTelefone.Modelos;
using System.Runtime.CompilerServices;

Console.WriteLine("Exercício Gerador Números Telefone");

//Instanciando a classe de servicos para acessarmos as suas funções
var servicos = new Servico();
//Pedindo a uf
var uf = Menus.MenuPegaEstado();
var validacaoUf = servicos.ValidaUf(uf);

//Pedindo o tipo do número
var tipoNumero = Menus.MenuPegaTipoNumero();
TipoTelefone tipoNumeroEnum = (TipoTelefone)Enum.Parse(typeof(TipoTelefone), tipoNumero);

//Verificando se vai ter a formatação do número
var temFormatacao = Menus.MenuPegaFormatacao();

var DddsAleatorio = servicos.RetornaDddAleatorioUf(uf);

if (DddsAleatorio == string.Empty)
{
    Console.WriteLine("\nUF informada não existe, gerando com UF aleatória... 😠");
    DddsAleatorio = servicos.RetornaDddAleatorioComUfAleatorio();
}

var numero = string.Empty;

switch (tipoNumeroEnum)
{
    case TipoTelefone.Fixo:
        if(temFormatacao == true)
        {
            Console.WriteLine("\nGerando número fixo...");
            numero = GeradorDeNumeros.GeraNumeroFixo();
            numero = numero.Insert(4, "-");
            numero = numero.Insert(0, $"({DddsAleatorio})");
        }
        else
        {
            Console.WriteLine("\nGerando número fixo...");
            numero = GeradorDeNumeros.GeraNumeroFixo();
            numero = numero.Insert(0, $"{DddsAleatorio}");
        }
		
        break;

    case TipoTelefone.Movel:
        if(temFormatacao == true)
        {
            Console.WriteLine("\nGerando número móvel...");
            numero = GeradorDeNumeros.GeraNumeroMovel();
            numero = numero.Insert(5, "-");
            numero = numero.Insert(0, $"({DddsAleatorio})");
        }
        else
        {
            Console.WriteLine("\nGerando número móvel...");
            numero = GeradorDeNumeros.GeraNumeroMovel();
            numero = numero.Insert(0, $"{DddsAleatorio}");
        }
        
        break;

    case TipoTelefone.NaoDefinido:
        if (temFormatacao == true)
        {
            Console.WriteLine("\nGerando número...");
            numero = GeradorDeNumeros.GeraNumeroNaoDefinido();
            numero = numero.Insert(4, "-");
            numero = numero.Insert(0, $"({DddsAleatorio})");
        }
        else
        {
            Console.WriteLine("\nGerando número...");
            numero = GeradorDeNumeros.GeraNumeroNaoDefinido();
            numero = numero.Insert(0, $"{DddsAleatorio}");
        }
        break;
}
Console.WriteLine($"\n{numero}");
