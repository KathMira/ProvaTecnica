# Gerador de Números de Telefone

Temos uma API criada para gerar dados aleatórios de clientes para fins de testes, que com base em um CPF, retorna informações de nome completo, data de nascimento, email e uma lista de telefones para essa pessoa. Um exemplo gerado:

```json
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
```

Porém, a biblioteca em questão usada pra gerar essas informações aleatórias não possui um método para geração de telefones especificamente para o Brasil, de forma que a chamada para gerar um número tem que ser feita através de uma máscara:

```csharp
f.Phone.PhoneNumber("## 9####-####")
``` 

Esse método infelizmente acaba gerando números de DDD inválidos (96 é do Amapá, mas 25 e 80 não existem), além de limitar apenas números de celular já que não permite gerar números de telefonia fixa ao mesmo tempo.

Para resolver esse problema, precisamos criar um método que possa ser chamado por essa API que seja capaz de gerar números de telefones válidos para a nossa realidade brasileira.

## Pontos a serem considerados

- deve ser utilizado o projeto CLI (template console do dotnet) "GeradorNumerosTelefone" passado como base;
- no projeto, foi criada uma classe com um método GerarNumero() que deve ser utilizado. A intenção é que esse seja o método a ser chamado pelo código da API durante a geração randômica;
- o método deve retornar apenas um número de telefone por vez, sendo responsabilidade de quem for usar chamá-lo quantas vezes quiser;
- o método deve ser capaz de gerar um número de telefone válido para cada um dos seguintes tipos:
  - Móvel Celular: [Especificação da Anatel](https://www.gov.br/anatel/pt-br/regulado/numeracao/tabela-servico-movel-celular) (Formato: 9XXXX-XXXX)
  - Fixo comutado: [Especificação da Anatel](https://www.gov.br/anatel/pt-br/regulado/numeracao/tabela-servico-telefonico-fixo-comutado) (Formato: 2XXX-XXXX; 3XXX-XXXX; 4XXX-XXXX; 5XXX-XXXX)
- o método deve receber uma configuração opcional para indicar qual tipo específico do item acima o chamador quiser. Caso não seja indicado pelo chamador, o método deve escolher aleatoriamente qual deles será gerado e retornado;
- o método deve possuir um parâmetro não obrigatório para indicar qual a UF deve ser usada durante a geração do número, permitindo que apenas os DDDs válidos para cada UF sejam escolhidos ([ver tabela em anexo](#anexo)). Caso não seja indicado pelo chamador, o método deve escolher aleatoriamente qualquer DDD válido para qualquer lugar do país.
- o retorno do método deve ter o número de telefone não formatado, com 2 dígitos do DDD + 9 ou 8 dígitos do número dependendo se é telefone móvel ou fixo comutado.

## Exemplos de Cenários de Testes

1) Qualquer tipo de telefone de qualquer UF:
    - Chamada:
        ```csharp 
        geradorTelefoneBrasil.GerarNumero();
        ```
    - Retorno aleatório:
        - 96979576482

2) Apenas telefones fixos, de qualquer UF
    - Chamada:
        ```csharp 
        geradorTelefoneBrasil.GerarNumero(TipoServicoTelefone.FixoComutado);
        ```
    - Retorno aleatório:
        - 1232465606

3) Qualquer tipo de telefone, mas apenas de SP
    - Chamada:
        ```csharp 
        geradorTelefoneBrasil.GerarNumero(uf: UFsBrasil.SP);
        ```
    - Retorno aleatório:
        - 11987254786

4) Apenas telefones móveis do centro-oeste
    - Chamada:
        ```csharp 
        geradorTelefoneBrasil.GerarNumero(TipoServicoTelefone.MovelPessoal, GeradorTelefoneBrasil.RegiaoCentroOeste);
        ```
    - Retorno aleatório:
        - 64971271576

5) Qualquer tipo de telefone, mas apenas do Sul e Sudeste
    - Chamada:
        ```csharp 
		var ufsSulSudeste = GeradorTelefoneBrasil.RegiaoSul.Concat(GeradorTelefoneBrasil.RegiaoSudeste).ToArray();
		geradorTelefoneBrasil.GerarNumero(uf: ufsSulSudeste);
        ```
    - Retorno aleatório:
        - 47997464216

## Anexo

| Região | UF | Códigos DDD |
| ------ | ------------ | ----------- |
| Centro-Oeste | Distrito Federal | 61 |
| Centro-Oeste | Goiás | 62 e 64 |
| Centro-Oeste | Mato Grosso | 65 e 66 |
| Centro-Oeste | Mato Grosso do Sul | 67 |
| Nordeste | Alagoas | 82 |
| Nordeste | Bahia | 71, 73, 74, 75 e 77 |
| Nordeste | Ceará | 85 e 88 |
| Nordeste | Maranhão | 98 e 99 |
| Nordeste | Paraíba | 83 |
| Nordeste | Pernambuco | 81 e 87 |
| Nordeste | Piauí | 86 e 89 |
| Nordeste | Rio Grande do Norte | 84 |
| Nordeste | Sergipe | 79 |
| Norte | Acre | 68 |
| Norte | Amapá | 96 |
| Norte | Amazonas | 92 e 97 |
| Norte | Pará | 91, 93 e 94 |
| Norte | Rondônia | 69 |
| Norte | Roraima | 95 |
| Norte | Tocantins | 63 |
| Sudeste | Espírito Santo | 27 e 28 |
| Sudeste | Minas Gerais | 31, 32, 33, 34, 35, 37 e 38 |
| Sudeste | Rio de Janeiro | 21, 22 e 24 |
| Sudeste | São Paulo | 11, 12, 13, 14, 15, 16, 17, 18 e 19 |
| Sul | Paraná | 41, 42, 43, 44, 45, 46 e 49 |
| Sul | Rio Grande do Sul | 51, 53, 54 e 55 |
| Sul | Santa Catarina | 42, 47, 48 e 49 |
