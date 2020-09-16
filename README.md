# SoftplanMP
projeto para o teste de engenharia de software da SoftPlan

===============================================================================
ATENÇÃO com os TESTES:

o projeto de teste da API 2 necessita que a API 1 esteja rodando.
Como o arquivo de configurações aponta pra uma URL local, o mesmo tem que estar rodando localmente.

Isso está assim pois não foi definido que a API 2 poderia usar um valor default no caso de não encontrar a API 1, 
e entendo que isso foi feito com a intenção de que cada API funcione como um micro serviço independente.

Caso necessite que o teste rode mesmo sem a presença da API 1 rodando, sugiro 3 alterações possíveis:

1) no timeout do método App2Service.GetInterestRate, retornar com valor default 0.01 (e lembrar de adicionar teste unitário nessa opção).
2) as API´s estarem no mesmo projeto, apenas separadas por controllers diferentes, e modificar os testes de acordo.
3) colocar a taxa de juros alternativa no entrypoint CalculateInterestRate com valor default 0.01, e usá-la preferencialmente ao invés de trazer da API 1.

