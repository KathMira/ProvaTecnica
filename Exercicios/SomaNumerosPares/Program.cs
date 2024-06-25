string[] argumentos = args;

//Console.WriteLine("Digite os números que deseja fazer a soma, separados por espaço: ");
var numerosDivididos = argumentos.FirstOrDefault()?.Split(',');
if (numerosDivididos == null)
{
    Console.WriteLine('0');
    return;
}
int[] inteiros = new int[numerosDivididos.Length];
int soma = 0;

for (int i = 0; i < numerosDivididos.Length; i++)
{
    var num = int.Parse(numerosDivididos[i]);
    inteiros[i] = num;
}
foreach (var numero in inteiros)
{
    if (numero % 2 == 0)
    {
        soma += numero;
        Console.WriteLine(soma);
    }
}