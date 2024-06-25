using GeradorNumerosTelefone.Modelos;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace GeradorNumerosTelefone.Menus;

public static class Menus
{
    public static string MenuPegaEstado()
    {
        Console.WriteLine("Insira a sigla do estado em que gostaria de gerar o número:");
        string uf = (Console.ReadLine()!);
        return uf;
    }

    public static string MenuPegaTipoNumero()
    {
        Console.WriteLine("\nQual o tipo de número que você deseja gerar o número?");
        Console.WriteLine("\nFixo   (1)");
        Console.WriteLine("Móvel    (2)");

        Console.Write("\nDigite a sua opção: ");
        string opcao = Console.ReadLine()!;
        return opcao;
    }

    public static bool MenuPegaFormatacao()
    {
        Console.WriteLine("\nFormatação? ");
        Console.WriteLine("\nSim   (1)");
        Console.WriteLine("\nNão   (2)");

        Console.Write("\nDigite a sua opção: ");
        var temFormatacao = Console.ReadLine()!;

        if (temFormatacao == "1")
            return true;
        
        return false;
        
    }

    
}
