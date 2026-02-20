Quero que você transforme a classe HttpClient abaixo em uma implementação baseada em JavaScript clássico sem modules, usando prototype.

Requisitos obrigatórios:

1. A classe deve ser estruturada como:
   - App.HttpClientWithEvents (função construtora)
   - métodos usando prototype
   - método send() central que recebe um HttpRequest
   - métodos auxiliares get/post/put/delete gerando HttpRequest

2. Implementar:
   - callbacks de eventos: started e finished
   - suporte a LoadingManager externo (apenas emitindo eventos, sem acoplar)
   - retry configurável
   - retryDelay configurável
   - retryStrategy: "linear" ou "exponential"
   - circuit breaker com:
        - circuitBreakerThreshold
        - circuitBreakerDuration

3. Não deve ler JSON, text ou blob dentro do client.
   A resposta deve ser retornada como Response puro, e o chamador decide como ler.

4. A estrutura deve ser compatível com ASP.NET MVC (sem ES Modules, sem export/import).

5. Exemplo do padrão organizacional esperado:

   /wwwroot/js/components/loading-manager.js
   /wwwroot/js/services/http-client-with-events.js
   /wwwroot/js/controllers/meu-script.js

6. A saída deve conter:
   - HttpRequest (função)
   - HttpClientWithEvents (função)
   - métodos no prototype
   - circuito de resiliência
   - eventos "started" e "finished"

7. Mantenha o código limpo e com responsabilidades separadas.

Aqui está minha classe original para ser convertida:

[cole aqui sua classe HttpClient atual]
