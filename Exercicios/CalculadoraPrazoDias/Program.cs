Console.WriteLine("Exercício CalculadoraPrazoDias");

/*
Em um cenário de atendimento ao consumidor, é comum que o atendente precise informar uma data de prazo para resposta de uma determinada solicitação que dependa de terceiros, como por exemplo, uma transportadora tem X dias para receber um produto e a área de qualidade mais Y dias para fazer a tratativa antes de dar uma devolutiva final.

Nesse exercício, a calculadora de prazos deve funcionar como uma aplicação console que recebe a data inicial da solicitação e a quantidade de dias que devem ser usadas no cálculo, retornando a data final do prazo calculada para que o atendente possa responder ao consumidor.

Pontos a serem considerados:

- deve ser utilizado o projeto CLI (template console do dotnet) "CalculadoraPrazoDias" passado como base;
- o programa deve receber primeiro a data inicial: caso a mesma seja vazia, deve ser considerado a data atual; caso a data seja preenchida, deve ser lida no formato "dia/mês/ano";
- em seguida, o programa deve receber a quantidade de dias a serem calculados: nesse caso, o valor precisa ser um número inteiro válido e maior que zero;
- o resultado final deve ser retornado em dias corridos no formato "dia/mês/ano".
*/
Console.WriteLine("Informe a data inicial:");
string? entradaDataInicial = Console.ReadLine();

Console.WriteLine("Informe a quantidade em dias do prazo:");
string? entradaDiasPrazo = Console.ReadLine();

DateTime dataInicial;

if (string.IsNullOrWhiteSpace(entradaDataInicial))
{
    dataInicial = DateTime.Now;
}
else
{
    try
    {
        dataInicial = DateTime.ParseExact(entradaDataInicial, "d", null);
    }
    catch (FormatException)
    {
        Console.WriteLine("Formato de data inválido, por favor, use o formato dd/mm/aaaa");
        return;
    }
}

DateTime dataFinal = dataInicial.AddDays(double.Parse(entradaDiasPrazo!));

Console.WriteLine($"\n\nData final: {dataFinal.Date}");