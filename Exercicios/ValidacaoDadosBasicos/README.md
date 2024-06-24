# Validação de Dados Básicos

O programa deve receber os dados de campos "Nome", "Idade" e "Data de Nascimento" como entrada da aplicação e validar seus valores com base em regras pré-estabelecidas.

## Regras de validação

- Nome não pode ser vazio e deve ter até 100 caracteres;
- Idade deve ser um dígito numérico inteiro, positivo e maior que zero;
- Data de nascimento deve ser uma data válida no formato "dia/mês/ano" e deve ser uma data no passado.

## Pontos a serem considerados

- deve ser utilizado o projeto CLI (template console do dotnet) "ValidacaoDadosBasicos" passado como base;
- o programa deve receber todos os valores e só então validar um por um;
- os valores devem ser recebidos na ordem indicada no enunciado;
- em caso de erro em qualquer campo, deve ser indicada qual regra não foi respeitada;
- não é necessário indicar sucesso para cada campo individualmente;
- caso todos os campos sejam válidos, o programa deve exibir a mensagem: "Dados recebidos com sucesso!";
- é esperado que sempre seja escrito um retorno no console, Exceptions lançadas que encerrem a aplicação serão considerados um erro.

## Pontos extra

- não faz parte das regras acima que a data de nascimento e a idade sejam correlacionados (ou seja, se a data de nascimento é X, então a pessoa teria Y anos hoje), mas implementá-la seria um ponto a mais

## Exemplos de Cenários de Testes

1) Todos os campos inválidos:

    Exemplo de Entrada:

    ```text
    Informe o nome:
    > ""
    Informe a idade:
    > "-5"
    Informe a data de nascimento:
    > "01/04/2222"
    ```

    Exemplo de Saída:

    ```text
    Campo "Nome" inválido: campo vazio!
    Campo "Idade" inválido: não é um número positivo (-5)
    Campo "Data de Nascimento" inválido: não pode ser uma data no futuro (01/04/2222)
    ```

2) Apenas um campo inválido:

    Exemplo de Entrada:

    ```text
    Informe o nome:
    > "Teste da Silva"
    Informe a idade:
    > "ABC"
    Informe a data de nascimento:
    > "13/02/2002"
    ```

    Exemplo de Saída:

    ```text
    Campo "Idade" inválido: não é um número inteiro (ABC)
    ```

3) Todos os campos válidos:

    Exemplo de Entrada:

    ```text
    Informe o nome:
    > "Teste da Silva"
    Informe a idade:
    > "30"
    Informe a data de nascimento:
    > "13/02/2002"
    ```

    Exemplo de Saída:

    ```text
    "Dados recebidos com sucesso!"
    ```
