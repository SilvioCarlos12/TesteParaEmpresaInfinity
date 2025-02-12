# TesteParaEmpresaInfinity

## Como executar a aplicação 

Primeiramente pricisará de uma instancia do banco postgresql, ou um docker.
Usando docker pode usar essa linha de comando 

docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres

Para modificação de password e usuario do banco de dados poderá usar
o arquivo appsettings.Development.json nele tem as config do banco.

Aplicação não irá rodar sem o banco dados configurado


## Migrations
Serão executadas automaticamente quando aplicação executada.

## Validação 

Usando como base Entidade Usuario, os campos Nome,
Telefone e Email são obrigatório.

Campo Telefone existe validação que checkagem se ele é segue
o padrão de 11 digitos e se são numericos, se não for apresentará
um erro => O telefone está no formato inválido.

Campo Email existe validação que checkagem se ele é segue padrão de
email tradicional se não for apresentará
um erro => O email esta no formato inválido.

## Escolhas Técnicas
 
 ### Padrão Result
   Usei padrão para facilita o retorno de erro e devolotiva para api.

 ### Refit
   Usei pela praticidade que ele dispõe para integrar com api externa.

 ### Arquitetura usada 

   Usei algo bem simples com 4 camadas => 
    1 Domain => onde fica modelo do usuario
    2 Infra => onde fica os repositorio tanto para banco de dados como para api
    3 Aplicacao => onde fica os serviços que acessa as outras camadas.
    4 Api => onde fica parte das rotas e das injeções dependencias.
    usei nessa arquitetura para facilita compreensão.

 ### Mapeamento
  
  Usei extensão para fazer inves do automapper,pois otimizar o mapeamento e
  como algo mais simples não necessidade do automapper.



