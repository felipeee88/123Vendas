O Sistema da empresa 123Vendas está dividido em domínios. Existem domínios específicos para gestão de Estoque, CRM (cliente) e Vendas. 
Você é um desenvolvedor do time de Vendas. Agora nós precisamos implementar um protótipo de API de vendas. 
Como trabalhamos com DDD, para referenciar entidades de outros domínios, nós fazemos uso do padrão de External Identities com a desnormalização do descritivo das entidades.
Assim, você vai escrever uma API (CRUD completo) que manipule os registros de vendas. A API precisa ser capaz de informar:
Número da venda; data em que a venda foi efetuada; cliente; valor total da venda; filial em que a venda foi efetuada; produtos; quantidades; valores unitário; descontos; valor total de cada item; Cancelado/Não Cancelado;
Não será obrigatório, mas seria um diferencial se você fizesse um código que para publicar eventos de CompraCriada, CompraAlterada, CompraCancelada; ItemCancelado. 
Se fizer o código, é dispensável publicar em algum Message Broker (Rabbit ou Service bus, por exemplo) de fato. 
Pode logar uma mensagem no log da aplicação ou como você achar mais conveniente.
Regras de negócio:
Compras acima de 4 itens iguais tem 10% de desconto;
Compras entre 10 e 20 itens iguais tem 20% de desconto;
Não é possível vender acima de 20 itens iguais;
Compras abaixo de 4 itens não podem ter desconto;
Você precisa utilizar na sua API:
Serilog para logs;
Divisão em camadas (API, Domain, Data);
Aplicar Git Flow workflow;
Aplicar Commit semântico;
APIs REST;
Clean Code;
SOLID;
DRY;
YAGNI;
Object Calisthenics;
Testes de unidade
XUnit;
FluentAssertions;
Bogus;
NSubstitute;
Boas práticas de escrita de código;
Teste de integração (desejável)
Test Container
