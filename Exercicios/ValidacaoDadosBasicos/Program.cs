using System.Text.RegularExpressions;

Console.WriteLine("Exercício ValidacaoDadosBasicos");

/*
O programa deve receber os dados de campos "Nome", "Idade" e "Data de Nascimento" como entrada da aplicação e validar seus valores com base em regras pré-estabelecidas.

As regras a serem utilizadas:

- Nome não pode ser vazio e deve ter até 100 caracteres;
- Idade deve ser um dígito numérico inteiro, positivo e maior que zero;
- Data de nascimento deve ser uma data válida no formato "dia/mês/ano" e deve ser uma data no passado.

Pontos a serem considerados:

- o programa deve receber todos os valores e só então validar um por um;
- os valores devem ser recebidos na ordem indicada no enunciado;
- em caso de erro em qualquer campo, deve ser indicada qual regra não foi respeitada;
- não é necessário indicar sucesso para cada campo individualmente;
- caso todos os campos sejam válidos, o programa deve exibir a mensagem: "Dados recebidos com sucesso!".
*/

Console.WriteLine("Informe o nome:");
string? entradaNome = Console.ReadLine();

Console.WriteLine("Informe a idade:");
string? entradaIdade = Console.ReadLine();

Console.WriteLine("Informe a data de nascimento:");
string? entradaDataNascimento = Console.ReadLine();

var ehvalidoh = true;

if (string.IsNullOrWhiteSpace(entradaNome))
{
    ehvalidoh = false;
    Console.WriteLine("Nome é vazio ou nulo");
}
if (Regex.IsMatch(entradaNome, "[0-9]+"))
{
    ehvalidoh = false;
    Console.WriteLine("Nome contém número");
}

int idade = 0;
try
{
    idade = int.Parse(entradaIdade);
    if (idade <= 0)
    {
        ehvalidoh = false;
        Console.WriteLine("A idade não pode ser menor ou igual a 0.");
    }
}
catch (Exception ex)
{
    ehvalidoh = false;
    Console.WriteLine("Idade é nula ou não é um número inteiro");
}

DateTime data;
if (DateTime.TryParse(entradaDataNascimento, out data))
{
    int idadeCalculada = DateTime.Now.Year - data.Year;

    if (DateTime.Now < data.AddYears(idadeCalculada))
    {
        idadeCalculada--;
    }
    if (idadeCalculada != idade)
    {
        ehvalidoh = false;
        Console.WriteLine("A idade não condiz com a data de nascimento.");
    }

    if (data > DateTime.Now)
    {
        ehvalidoh = false;
        Console.WriteLine("Data de nascimento não pode ser no futuro.");
    }
    if (data < DateTime.Now.AddYears(-124))
    {
        ehvalidoh = false;
        Console.WriteLine("Muito velho, não pode fazer cadastro.");
    }
}
else
{
    ehvalidoh = false;
    Console.WriteLine("Data inválida!");
}

if (ehvalidoh is true)
{
    Console.WriteLine($"Dados recebidos com sucesso!");
}
