using ConsultaEndereco.Classes;
using System.Text.Json;
using System.Text.RegularExpressions;

Console.WriteLine("Exercício ConsultaEndereco");

/*
    Faça uma aplicação capaz de acessar a api do Via CEP: https://viacep.com.br
    A aplicação deve receber os dados do usuário e retornar o endereço encontrado 

    Exemplo de entrada: 01001000

    Exemplo de Saída:
          Estado:  SP
          Cidade:  São Paulo
          Bairro:  Sé
          Logradouro:  Praça da Sé

    Processo:
        - O usuário deve informar o cep (com o traço ou sem) e cabe ao programa validá-lo e trazer o endereço encontrado

    Regra: 
        - Validar o CEP que não pode receber letras ou caracteres especiais, além que deve ter 8 digitos

    Sinta-se a vontade para exibir a quantidade de campos que quiser :)

    ***************************************************************
    BÔNUS:  
        O desafio extra será uma busca por parte do endereço caso o usuário não conheça o CEP
        A api do via CEP permite uma busca utilizando da UF, Localidade e Logradouro: https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/

        O usuário deve ter a opção de escolha entre a pesquisa de endereço por CEP ou sem o CEP.

        Exemplo de entrada:
            Informe a UF:
                GO
            Informe a Cidade:
                Goiana
            Informe o Logradouro:
                José

        Exemplo de saída:
            74683-735
            GO
            Goiânia
            Vila Santa Cruz
            Rua São José
            
            74455-437
            GO
            Goiânia
            São Francisco
            Rua São José
            
            74370-376
            GO
            Goiânia
            Condomínio Santa Rita - 2ª Etapa
            Rua São José

        Processo: 
            - O usuário deve informar uma UF válida (existe um arquivo ufs.js na raiz da aplicação para validar as Ufs) - é opcional o uso do arquivo json
            - O usuário deve informar a Localidade (cidade/municipio)
            - O usuário deve informar o Logradouro (avenida/estrada/rua/etc..)
    
        Regras:
            - Receber a UF com sigla(SP) ou nome(São Paulo), a acentuação não deve influenciar na entrada do usuário.
            - Validar se a UF informada existe antes de consultar a API

        A api retorna uma lista com os principais resultados. Você deve exibi-la para o usuário com as principais informações dos endereços encontrados.
    ***************************************************************
 */
Console.WriteLine("Busca CEP");
Console.WriteLine("\n Como você deseja buscar?");
Console.WriteLine("CEP     (1)");
Console.WriteLine("Sem CEP (2)");
var opcao = Console.ReadLine();

switch (opcao)
{
    case "1":
        await ProcuraPorCEP();
        break;
    case "2":
        await ProcuraSemCEP();
        break;
}

async Task ProcuraPorCEP()
{
    string CEP;
    Console.WriteLine("Informe o CEP:");
    CEP = Console.ReadLine()!;
    if (Regex.IsMatch(CEP, "^\\d{5}-\\d{3}$") || Regex.IsMatch(CEP, @"^\d{8}$"))
    {
        CEP.Trim('-');
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://viacep.com.br/ws/");
        var resposta = await client.GetStringAsync($"{CEP}/json");
        if (resposta.Contains("erro"))
        {
            Console.WriteLine("Verifique o CEP e tente novamente. essa n ta igual");
            return;
        }

        Endereco endereco = JsonSerializer.Deserialize<Endereco>(resposta, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        Console.WriteLine($"\nEstado:{endereco.Uf}");
        Console.WriteLine($"Cidade:{endereco.Localidade}");
        Console.WriteLine($"Bairro:{endereco.Bairro}");
        Console.WriteLine($"Logradouro:{endereco.Logradouro}");
    }
    else
    {
        Console.WriteLine("Verifique o CEP e tente novamente.");
    }
}

async Task ProcuraSemCEP()
{
    Console.WriteLine("Digite a Uf:");
    string Uf = Console.ReadLine()!;
    Console.WriteLine("Digite o Cidade:");
    string Localidade = Console.ReadLine()!;
    Console.WriteLine("Digite o Logradouro:");
    string Logradouro = Console.ReadLine()!;

    StreamReader r = new StreamReader("../../../ufs.json");

    string json = r.ReadToEnd();
    var ufs = JsonSerializer.Deserialize<List<Uf>>(json);

    bool ExisteUf = false;
    foreach (var estado in ufs)
    {
        if (estado.Sigla.Equals(Uf.ToUpper()))
        {
            ExisteUf = true;
        }
    }
    if (ExisteUf == false)
    {
        Console.WriteLine("Verifique a Uf.");
        return;
    }
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
    var resposta = await client.GetStringAsync($"{Uf}/{Localidade}/{Logradouro}/json");
    if (resposta.Contains("erro"))
    {
        Console.WriteLine("Verifique as informações e tente novamente.");
        return;
    }
    Endereco[] enderecos = JsonSerializer.Deserialize<Endereco[]>(resposta, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    if (enderecos.Length == 0)
    {
        Console.WriteLine("\nsNão retornou nada");
        return;
    }
    foreach (var end in enderecos)
    {
        Console.WriteLine($"\nCEP:{end.Cep}");
        Console.WriteLine($"Uf:{end.Uf}");
        Console.WriteLine($"Cidade:{end.Localidade}");
        Console.WriteLine($"Bairro:{end.Bairro}");
        Console.WriteLine($"Logradouro:{end.Logradouro}");
    }

}
