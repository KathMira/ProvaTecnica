# Calculadora de Prazo por Dias

Em um cenário de atendimento ao consumidor, é comum que o atendente precise informar uma data de prazo para resposta de uma determinada solicitação que dependa de terceiros, como por exemplo, uma transportadora tem X dias para receber um produto e a área de qualidade mais Y dias para fazer a tratativa antes de dar uma devolutiva final.

Nesse exercício, a calculadora de prazos deve funcionar como uma aplicação console que recebe a data inicial da solicitação e a quantidade de dias que devem ser usadas no cálculo, retornando a data final do prazo calculada para que o atendente possa responder ao consumidor.

## Pontos a serem considerados

- deve ser utilizado o projeto CLI (template console do dotnet) "CalculadoraPrazoDias" passado como base;
- o programa deve receber primeiro a data inicial: caso a mesma seja vazia, deve ser considerado a data atual; caso a data seja preenchida, deve ser lida no formato "dia/mês/ano";
- em seguida, o programa deve receber a quantidade de dias a serem calculados: nesse caso, o valor precisa ser um número inteiro válido e maior que zero;
- o resultado final deve ser retornado em dias corridos no formato "dia/mês/ano".

## Pontos extra

- além de retornar a data no formato "dia/mês/ano", seria útil retornar junto a informação do dia da semana como por exemplo: 18/02/2002 (Segunda-feira);
- para tornar o exercício mais difícil, seria útil ter a opção de calcular o prazo em dias úteis (desconsiderando sábado e domingo);
- para complicar mais um pouco, seria útil ter a opção de olhar para os feriados nacionais, desconsiderando eles como dias úteis. É possível consultar listas de feriados nacionais através APIs gratuítas como [essa da BrasilAPI por exemplo](https://brasilapi.com.br/docs#tag/Feriados-Nacionais).

## Exemplos de Cenários de Testes

1) Todos os campos preenchidos:

    Exemplo de Entrada:

    ```text
    Informe a data inicial:
    > "13/02/2002"
    Informe a quantidade em dias do prazo:
    > "5"
    ```

    Exemplo de Saída:

    ```text
    18/02/2002
    ```

2) Sem a data inicial preenchida (considerando que o dia atual seja 27/06/2016)

    Exemplo de Entrada:

    ```text
    Informe a data inicial:
    > ""
    Informe a quantidade em dias do prazo:
    > "21"
    ```

    Exemplo de Saída:

    ```text
    18/07/2016
    ```
