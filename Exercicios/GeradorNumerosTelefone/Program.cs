using GeradorNumerosTelefone;
using System;
using System.Linq;

Console.WriteLine("Exercício Gerador Números Telefone");

/*
Temos uma API criada para gerar dados aleatórios de clientes para fins de testes, que com base em um CPF, 
retorna informações de nome completo,
data de nascimento, email e uma lista de telefones para essa pessoa. Um exemplo gerado:

{
	"cpf": "81709094060",
	"nome": "Lara Barros",
	"dataNascimento": "1971-09-19",
	"email": "Lara_Barros70@live.com",
	"telefones": [
		"96 97878-1128",
		"25 99183-1929",
		"80 91245-5200"
	]
}

Porém, a biblioteca em questão usada pra gerar essas informações aleatórias não possui um método para geração 
de telefones especificamente para o Brasil,
de forma que a chamada para gerar um número tem que ser feita através de uma máscara:

f.Phone.PhoneNumber("## 9####-####")

Esse método infelizmente acaba gerando números de DDD inválidos (96 é do Amapá, mas 25 e 80 não existem),
além de limitar apenas números de celular já que não permite gerar números de telefonia fixa ao mesmo tempo.

Para resolver esse problema, precisamos criar um método que possa ser chamado por essa API que seja
capaz de gerar números de telefones válidos para a nossa realidade brasileira.

Pontos a serem considerados:

- no projeto, foi criada uma classe com um método GerarNumero() que deve ser utilizado.
A intenção é que esse seja o método a ser chamado pelo código da API durante a geração randômica;
- o método deve retornar apenas um número de telefone por vez, s0endo responsabilidade de quem for usar chamá-lo quantas vezes quiser;
- o método deve ser capaz de gerar um número de telefone válido para cada um dos seguintes tipos:
	-Móvel Celular: https://www.gov.br/anatel/pt-br/regulado/numeracao/tabela-servico-movel-celular (Formato: 9XXXX-XXXX)
	-Fixo comutado: https://www.gov.br/anatel/pt-br/regulado/numeracao/tabela-servico-telefonico-fixo-comutado
(Formato: 2XXX-XXXX; 3XXX-XXXX; 4XXX-XXXX; 5XXX-XXXX)
- o método deve receber uma configuração opcional para indicar qual tipo específico do item acima o chamador quiser. 
Caso não seja indicado pelo chamador,
o método deve escolher aleatoriamente qual deles será gerado e retornado;
- o método deve possuir um parâmetro não obrigatório para indicar qual a UF deve ser usada durante a geração do número, 
permitindo que apenas os DDDs válidos para cada UF sejam escolhidos (ver tabela em anexo).
Caso não seja indicado pelo chamador, o método deve escolher aleatoriamente qualquer DDD válido para qualquer lugar do país.
- o retorno do método deve ter o número de telefone não formatado, com 2 dígitos do DDD + 9 ou 8 dígitos do número dependendo se é telefone móvel ou fixo comutado.
*/

var geradorTelefoneBrasil = new GeradorTelefoneBrasil();

// exemplos de chamadas que podem ser feitas para diferentes gerações de números:

// qualquer tipo de telefone de qualquer uf
//Console.WriteLine($"Número gerado: {geradorTelefoneBrasil.GerarNumero()}");

// apenas telefones fixos, de qualquer UF
//Console.WriteLine($"Número gerado: {geradorTelefoneBrasil.GerarNumero(TipoServicoTelefone.FixoComutado)}");

// qualquer tipo de telefone, mas apenas de SP
//Console.WriteLine($"Número gerado: {geradorTelefoneBrasil.GerarNumero(uf: UFsBrasil.SP)}");

// apenas telefones móveis do centro-oeste
//Console.WriteLine($"Número gerado: {geradorTelefoneBrasil.GerarNumero(TipoServicoTelefone.MovelPessoal, GeradorTelefoneBrasil.RegiaoCentroOeste )}");

// qualquer	tipo de telefone, mas apenas do Sul e Sudeste
//var ufsSulSudeste = GeradorTelefoneBrasil.RegiaoSul.Concat(GeradorTelefoneBrasil.RegiaoSudeste).ToArray();
//Console.WriteLine($"Número gerado: {geradorTelefoneBrasil.GerarNumero(uf: ufsSulSudeste)}");



//Console.WriteLine(GeradorTelefoneBrasil.RegiaoSul[0]);