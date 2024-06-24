# Consulta Endereço

Existe uma API popular para a consulta de endereços por meio de CEP ou de uma pesquisa genérica da localização informada.

Faça uma aplicação capaz de acessar a api do Via CEP: [https://viacep.com.br](https://viacep.com.br)

A aplicação deve receber os dados do usuário e retornar o endereço encontrado

- Exemplo de entrada:

```text
Informe o CEP: 
> 01001000
```

- Exemplo de Saída:

```text
Estado: SP
Cidade: São Paulo
Bairro: Sé
Logradouro: Praça da Sé
```

## Processo

- O usuário deve informar o cep (com o traço ou sem) e cabe ao programa validá-lo e trazer o endereço encontrado.

## Regra

- A API requer como parâmetro um CEP sem letras ou caracteres especiais e com apenas 8 dígitos, então o programa deve garantir que o CEP está no formato correto antes da requisição.

💡 Sinta-se a vontade para exibir a quantidade de campos que quiser :)

---

## BÔNUS

O desafio extra será uma busca com a parte do endereço caso o usuário não conheça o CEP.

A api do via CEP permite uma busca utilizando da UF, Localidade e Logradouro: [https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/](https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/)

O usuário deve ter a opção de escolha entre a pesquisa de endereço por CEP ou sem o CEP.

Exemplo de entrada:

```text
Informe a UF: 
> GO
Informe a Cidade:
> Goiania
Informe o Logradouro:
> José
```

Exemplo de saída:

```text
Cep: 74683-735
Uf: GO
Localidade: Goiânia
Bairro: Vila Santa Cruz
Rua São José

Cep: 74455-437
Uf: GO
Localidade: Goiânia
Bairro: São Francisco
Rua São José

Cep: 74370-376
Uf: GO
Localidade: Goiânia
Bairro: Condomínio Santa Rita - 2ª Etapa
Rua São José
```

## Processo

- O usuário deve informar uma UF válida (existe um arquivo ufs.js na raiz da aplicação para validar as Ufs) - é opcional o uso do arquivo json
- O usuário deve informar a Localidade (cidade/municipio)
- O usuário deve informar o Logradouro (avenida/estrada/rua/etc..)

## Regras

- Receber a UF com sigla(SP) ou nome(São Paulo), a acentuação não deve influenciar na entrada do usuário.
- Validar se a UF informada existe antes de consultar a API

 A api retorna uma lista com os principais resultados. Você deve exibi-la para o usuário com as principais informações dos endereços encontrados.

---
