# GERENCIADOR DE TROCAS E DEVOLUÇÕES PARA E-COMMERCE
 ----Este projeto é utilizado por uma empresa profissionalmente e já faz parte do processo interno para resolução de problemas dela---<br/>
 <br/>
Quem trabalha com vendas, principalmente online, sabe que a todo momento produtos que foram enviados retornam para o CD, seja por algum defeito, cliente não gostou, tentativas de entregas falhas etc.
As vezes os produtos apenas voltam, mas por vezes, temos que reenviar um novo para o cliente.

Esse software nasceu com a necessidade de melhorar a comunicação dos responsavéis por esse processo, que antes era feito por uma planilha do excel, que dificultava a visualicação e o acompanhamento,
e também para esses dados serem guardados de uma forma mais segura e mais facil de serem utilizados em futuras analises de dados.

Ele tem 3 tipos de responsabilidades:

  -<b>Suporte: Ele entra em contato direto com o cliente para resolver o problema, e caso haja a necessidade de um reenvio, ele é responsável por cadastrar essa reposição no aplicativo.<br/>
  <br/>
  -Compras: Este é responsável pela disponibilidade do produto, as vezes é um produto que não tem estoque, ou que tem que ser fabricado, comprado e ele é responsável por visualizar
  e pedir esse produto, com sua parte feita ele tem um campo na parte dos detalhes da reposição para informar aos outros que já realizou o pedido.<br/>
  <br/>
  -Logística : responsável por realizar o envio desse produto, dentro do prazo, que é selecionado de acordo com niveís de prioridade definidos pelo suporte na hora de cadastrar.<br/><b/>

Apesar de ter 3 responsabilidades ele comporta diversos usuários de acordo com a necessidade.<br/>
Cada tipo de usuário tem suas permissões dentro do aplicativo e não podem alterar informações dos outros.

## Tecnologias utilizadas:<br/>
 -Microsoft SQL Server<br/>
 -Azure Database<br/>
 -Guna 2 UI FrameWork<br/>
 -Micro ORM Dapper<br/>
 -C# .NET<br/>



# Telas do aplicativo:

### Tela de login:

-Com uma interface moderna e intuitiva essa tela, assim como todo o App, foi construido com o FrameWork de UI Guna2 UI

![login](https://github.com/user-attachments/assets/d1000a6b-b603-4d12-a709-d3cfae8034de)

## Tela de carregamento:
 
![Login](https://github.com/user-attachments/assets/f296bec1-b4f9-489d-b3bc-be1cb7aad3e9)

## Tela Inicial:

-Essa tela contem um botão de ajuda para caso haja algum problema com o app e é onde coloco as atualizações para os usuários já entratrem e visualizarem.

![pag_inicial](https://github.com/user-attachments/assets/42583865-ba21-4502-8d96-164bf062c45e)

## Tela das reposições:

-Essa é a tela onde podemos vizualizar todas as ultimas 50 reposições(foram limitados a 50 pois é o suficiente no momento mas pode ser colocado a quantidade de registros desejado),
aqui podemos ver todas reposições, apenas as pendentes, faturadas, que são as que a logistica já preparou o envio mas ainda não foi enviada, enviadas, e atrasadas, que são as que já passaram da data prevista para o envio.<br/>
Ela exibe as informações de forma resumida para que fique facil visualizar e já saber do que se trata aquele registro.

![pag_rep](https://github.com/user-attachments/assets/36ec3128-df9e-46e8-8a1a-d7f684ef7c53)


## Tela de registro:

-Essa é a tela onde o suporte registra a reposição para dar início ao processo

![pag_reg](https://github.com/user-attachments/assets/aa7493d0-3e27-4b01-86df-04a8b5039e78)

## Tela de detalhes da reposição

-Aqui é o local onde é possivel ver todas as informaçõs a respeito daquela reposição, quando foi registrada, informações do cliente para criação da nota fiscal, informações do produto, quantidade, se não havia em estoque, se já foi pedido,
fotos, anotações dos outros responsáveis pelo processo.
<br/>
Os detalhes da reposição é onde o responsavel pelas compras informa se já pediu o produto, o usuário da logística informa se já enviou o pedido, por qual transportadora enviou, e tudo isso é datado para caso haja algum problema seja possível ver
quando os passos do processo aconteceram.

![pag_deta](https://github.com/user-attachments/assets/5bbc7378-7752-4949-a4ae-6d633ee25c18)

## Tela de Imagens:

-Tela que exibe as fotos que o suporte colocou como provas do que aconteceu com o produto, para que caso necessario
![PAG_FTS](https://github.com/user-attachments/assets/4a6a8a50-9846-42c6-ba1e-b5d58f4da6bb)
