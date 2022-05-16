---
title: Desafio DDD
created: "2022-04-11T08:11:46.053Z"
modified: "2022-04-14T14:00:33.087Z"
---

# Desafio DDD

## Models

Cada classe vai derivar da ClassModel base com já o Id nela.

### Pedido

<details>
  <summary></summary>
- ID GUID <>
- Code long
- Date DateTime
- DeliveryDate DateTime
- Products
  - ProductDescription string
  - ProductCategory int
  - Quantity decimal
  - Value decimal
- Client GUID
- ClientDescription string
- ClientEmail string
- ClientPhone string
- Status enum
- Street string
- Number string
- Sector string,
- Complement string
- City string
- State string
- Discount decimal
- Cost decimal
</details>

### Documentos

<details>
  <summary></summary>

- ID GUID <>
- Number string
- Date DateTime
- DocumentType int
- Operation int
- Paid bool
- PaymentDate DateTime
- Description string
- Total decimal
- Observation string
</details>

### Livro Caixa

<details>
  <summary></summary>

- ID <>
- Origem
- OrigemID
- Descrição
- Tipo
- Valor
</details>

## Notas

- Tentar meter o Id na BaseModel porque não estava a dar queixava-se de que não tinha Setter, e aproveitar para ver
  se da para meter mais qual quer coisa la
- Fluent API??
- tentar ja implementar os returnos patrões que pediram
  - [x] Pedido
  - [x] Documentos
  - [x] Livro Caixa

## Importante

[ ] - Mesmo diretório para às 3 api’s.Isso dificulta o versionamento no GIT quando mais de um dev está atuando no projeto.(Como ainda estamos no github alterar para pastas)
[x] - Contexto do DDD ficou compartilhado para as três api’s. Cada Api deve ter o seuApplication, Dominio e Data separados.
[x] - RepositoryBase se encontra no csproj Data, entendo que ele deveria estar no Shared pois será a lib compartilhada para as 3 api’s
[ ] - DataContext - Buscar connection do SQL Server do appsettings.

### API BuyRequest

| ToDo                                                                                                                                                                                      | <span>:pencil2:</span>                | <span>:white_check_mark:</span>       |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------- | ------------------------------------- |
| ** Program - Criar Extension para configuração do AutoMapper **                                                                                                                           | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** Program - Criar Extension para configuração dos Service/Repository **                                                                                                                  | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestController - \_logger nao está sendo utilizado. **                                                                                                                           | <input type="checkbox" checked/> TODO | <input type="checkbox" /> DONE        |
| ** BuyRequestController Criar abstração no seu controller base para retorno de NoContent() dos métodos Get **                                                                             | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestController - Criar abstração no seu controller base para retorno de NoContent() dos métodos Get **                                                                           | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** ApplicationBuyRequestService - GetAll - Paginação está sendo feita da camada de Application, deveria ser feito na camada de Repository. **                                             | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| \*\* Metodo \_buyRequestService.GetAll() está fazendo um ToListAsync() antes dapaginação.                                                                                                 |                                       |                                       |
| Os metodos que convertem um IQuery para lista são os que passam para a memoriatoda a informação que vc está buscando.                                                                     |                                       |                                       |
| Fazer paginação antes do primeiro ToList. \*\*                                                                                                                                            | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| \*\* ApplicationBuyRequestService - GetAll - Count da quantidade de pagina está sendofeito no GetAll que retorna toda a sua entidade para a memoria                                       |                                       |                                       |
| Pesquisar forma correta de realizar um count sem trazer todo o objeto para a memoria. \*\*                                                                                                | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** ApplicationBuyRequestService - GetById - Colocar return na linha do Map **                                                                                                             | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** ApplicationBuyRequestService - Add - Colocar return na linha do service **                                                                                                             | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - Add - dbSet.AddAsync está sem await **                                                                                                                          | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - Add - Criar abstração para comunicação com api de CashBook nao é obrigação do repository fazer esse envio. **                                                   | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** Utilizar AutoMapper para converter BuyRequest para CashBookDto **                                                                                                                      | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** Utilizar AutoMapper para converter BuyRequest para CashBookDto **                                                                                                                      | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** ApplicationBuyRequestService - Update - Colocar return na linha do service.Update **                                                                                                   | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestService - Update - Caso nao seja uma Entidade Valida nem precisarealizar a consulta do GetById, adicionar validação antes. **                                                | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - GetById - Está sendo realizado uma consulta por Client ou Id, criar metodo separado para busca por Client, busca por Client nao condiz com o nome do método. ** | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - Update - Utilizar abstração para comunicação com API de CashBook. **                                                                                            | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestController - Patch - Qual a diferença do seu Update e Patch ? Porenquanto não será necessário remove-lo. **                                                                  | <input type="checkbox" checked/> TODO | <input type="checkbox" /> DONE        |
| ** ApplicationBuyRequestService - Remove - Colocar return na msm linha. **                                                                                                                | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| \*\* BuyRequestRepository - Remove - Está realizada duas consulta no banco pelo Id, criar novo método para deletar por objeto, para que não seja preciso buscarnovamente.                 |                                       |                                       |
| Utilizar abstração para comunicação com API de CashBook.\*\*                                                                                                                              | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - Remove - Não está sendo validado se existe pelo Id, caso passe um Id inexistente dará erro. E o delete quando passa um Id inexistente deve retornar true. **    | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |
| ** BuyRequestRepository - Remove - Metodo está retornar um, BuyRequest mas esse objeto acabou de ser deletado, alterar para boolean. **                                                   | <input type="checkbox" /> TODO        | <input type="checkbox" checked/> DONE |

## [Activity](#NOTE:0)

| Critérios Pedidos                                                                                                                          | <span>:white_check_mark:</span>       | <span>:grey_question:</span>   | <span>:pencil2:</span>         |
| ------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------- | ------------------------------ | ------------------------------ |
| **Sempre que o Pedido for criado ele nascerá como Recebido.**                                                                              | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um Pedido não pode conter Produtos dos dois Tipos(Digital e Físico).**                                                                   | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um Pedido com Produto do Tipo Físico não pode ser setado para o Status AguardandoDownload.**                                             | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um Pedido com Produto do Tipo Digital não pode ser setado para o Status AguardandoEntrega.**                                             | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Nao pode ser adicionado dois produtos iguais no mesmo pedido**                                                                           | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um pedido com o Status Finalizado nao pode voltar para os Status anteriores, somente deletado.**                                         | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um pedido for marcado como Finalizado deverá comunicar com a API de Livro Caixa e gerar uma entrada de movimentação financeira.** | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um pedido Finalizado for deletado deverá comunicar com a API de Livro Caixa e gerar uma movimentação de estorno.**                | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um pedido Finalizado for alterado o seu valor deverá comunicar com a API de Livro Caixa e gerar uma movimentação da diferença.**  | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um pedido for integrado com o Livro Caixa a descricao deverá ser "Pedido de Compra n°XXXX"**                                      | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |

## [Activity](#NOTE:0)

| Critérios Documentos                                                                                                                             | <span>:white_check_mark:</span>       | <span>:grey_question:</span>   | <span>:pencil2:</span>         |
| ------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------- | ------------------------------ | ------------------------------ |
| **Quando um Documento for marcado como Pago deverá comunicar com a API de Livro Caixa e gerar uma movimentação financeira de entrada ou saida.** | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um Documento Pago for deletado deverá comunicar com a API de Livro Caixa e gerar uma movimentação de estorno.**                         | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Quando um Documento Pago for alterado o seu valor deverá comunicar com a API de Livro Caixa e gerar uma movimentação da diferença.**           | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |

## [Activity](#NOTE:0)

| Critérios Livro Caixa                                                                         | <span>:white_check_mark:</span>       | <span>:grey_question:</span>   | <span>:pencil2:</span>         |
| --------------------------------------------------------------------------------------------- | ------------------------------------- | ------------------------------ | ------------------------------ |
| **Um Livro Caixa inserido por integração não pode ser Alterado.**                             | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um Livro Caixa do Tipo Pagamento não pode ter Valor positivo.**                             | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Um Livro Caixa do Tipo Recebimento não pode ter Valor negativo.**                           | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
| **Requisicao de GET All deverá retornar o campo Total, com o valor total de Movimentações..** | <input type="checkbox" checked/> DONE | <input type="checkbox" /> TEST | <input type="checkbox" /> TODO |
