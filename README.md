# Durango

Durango é um aplicativo para gerenciamento financeiro pessoal com o objetivo de ajudar as pessoas a controlar seus gastos, investimentos, empréstimos, financiamentos e consórcios.

## Funcionalidades

- Uso de IA para sugerir metas, orçamentos, investimentos, conteúdo de educação financeira, alerta de gastos excessivos e notificações de economia de acordo com o perfil do usuário;
- Integração com a Open Banking para visualização e importação de extrato bancário e transações em tempo real, inclusas movimentações de cartão de crédito;
- Cadastro de receitas e despesas;
- Cadastro de contas bancárias, carteiras e cartões de crédito;
- Lançamento automático e manual de movimentações financeiras parceladas, recorrentes e fixas;
- Categorização automática e manual de movimentações financeiras;
- Acompanhamento de financiamentos, empréstimos pessoais e consignados, consórcios e gestão de contratos;
- Educação financeira acessível;
- Função para avaliar a necessidade de uma compra, afim de educar o usuário para compras por impulso;
- Gerenciamento e sugestão de investimentos com base no perfil de usuário;

## Tecnologias utilizadas

O aplicativo Durango foi desenvolvido utilizando as seguintes tecnologias:

- Postgres: para armazenamento de dados;
- Angular: para a construção do aplicativo mobile;
- .NET Core: para a criação da API;

## Como rodar o projeto

Para rodar o projeto, siga os passos abaixo:

1. Clone o repositório usando o comando `git clone https://github.com/bvnovaes/durango.git`
2. Na pasta do projeto, execute o comando `docker-compose up -d` para iniciar o banco de dados
3. Acesse a pasta `api` e execute o comando `dotnet run` para iniciar a API

## Como contribuir

1. Faça um fork do projeto
2. Crie uma branch com a feature ou correção que deseja fazer: `git checkout -b minha-feature`
3. Faça as alterações necessárias e commit: `git commit -m "Minha feature"`
4. Envie suas alterações para o repositório remoto: `git push origin minha-feature`
5. Crie um pull request no repositório original

## Autores

Este projeto foi criado por [Bruno Novaes](https://github.com/bvnovaes).

## Licença

Este projeto é distribuído sob a licença [Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License][cc-by-nc-sa]. Consulte o arquivo [LICENSE](LICENSE.md) para mais informações.

[![CC BY-NC-SA 4.0][cc-by-nc-sa-image]][cc-by-nc-sa]

[cc-by-nc-sa]: http://creativecommons.org/licenses/by-nc-sa/4.0/
[cc-by-nc-sa-image]: https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png
[cc-by-nc-sa-shield]: https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-lightgrey.svg
