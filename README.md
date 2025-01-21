# Order Management Application

## 📜 Descrição do Projeto
A aplicação **Order Management App** foi desenvolvida em C# para gerenciar pedidos de clientes de forma eficiente. O sistema permite criar, visualizar, atualizar, excluir e filtrar pedidos. A solução é robusta, utilizando o framework ASP.NET Core e MediatR para oferecer uma arquitetura escalável e moderna.

## ✨ Funcionalidades
- Cadastro de novos pedidos com validações detalhadas.
- Atualização de pedidos existentes.
- Exclusão de pedidos por ID.
- Consulta detalhada de pedidos por ID.
- Filtro de pedidos com base em critérios como nome do cliente e intervalo de datas.
- Retorno consistente de mensagens para erros ou ações bem-sucedidas.

## 🔟 Público-Alvo
A solução é destinada a empresas ou equipes que necessitam de uma ferramenta para gerenciar os pedidos de seus clientes, garantindo agilidade no processo de criação e acompanhamento de pedidos.

---

## 🛠️ Tecnologias Utilizadas
- **C#** com ASP.NET Core.
- **MediatR** para a implementação de comandos e queries.
- **Swagger** (se configurado) para documentação da API.
- **Dependency Injection** para desacoplamento e flexibilidade do código.

---

## 🚀 Instruções para Rodar Localmente
### Pré-requisitos
1. **.NET SDK 6.0 ou superior** instalado.
2. Banco de dados configurado (se necessário, substituir a configuração no `appsettings.json`).
3. IDE recomendada: **Visual Studio** ou **Visual Studio Code**.

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-repositorio/order-management-app.git
   cd order-management-app
   ```
2. Restaure os pacotes do projeto:
   ```bash
   dotnet restore
   ```
3. Compile o projeto:
   ```bash
   dotnet build
   ```
4. Rode a aplicação:
   ```bash
   dotnet run
   ```
5. Acesse o Swagger na URL padrão:
   ```
   http://localhost:5000/swagger
   ```

---

## 🥽 Exemplos de Chamadas aos Endpoints
### 1. **Obter todos os pedidos**
   **Endpoint**: `GET /api/orders`  
   **Exemplo de chamada com curl**:
   ```bash
   curl -X GET http://localhost:5000/api/orders
   ```

### 2. **Criar um novo pedido**
   **Endpoint**: `POST /api/orders`  
   **Exemplo de payload JSON**:
   ```json
   {
       "nomeCliente": "João Silva",
       "items": [
           {
               "nomeItem": "Teclado Mecânico",
               "quantidade": 2,
               "precoUnitario": 350.00
           },
           {
               "nomeItem": "Mouse Gamer",
               "quantidade": 1,
               "precoUnitario": 120.00
           }
       ]
   }
   ```
   **Chamada com curl**:
   ```bash
   curl -X POST http://localhost:5000/api/orders \
   -H "Content-Type: application/json" \
   -d '{
       "nomeCliente": "João Silva",
       "items": [
           {
               "nomeItem": "Teclado Mecânico",
               "quantidade": 2,
               "precoUnitario": 350.00
           },
           {
               "nomeItem": "Mouse Gamer",
               "quantidade": 1,
               "precoUnitario": 120.00
           }
       ]
   }'
   ```

### 3. **Consultar pedido por ID**
   **Endpoint**: `GET /api/orders/{id}`  
   **Exemplo de chamada com curl**:
   ```bash
   curl -X GET http://localhost:5000/api/orders/123e4567-e89b-12d3-a456-426614174000
   ```

### 4. **Atualizar um pedido existente**
   **Endpoint**: `PUT /api/orders/{id}`  
   **Exemplo de payload JSON**:
   ```json
   {
       "nomeCliente": "Maria Oliveira",
       "items": [
           {
               "nomeItem": "Cadeira Gamer",
               "quantidade": 1,
               "precoUnitario": 900.00
           }
       ]
   }
   ```

### 5. **Excluir um pedido**
   **Endpoint**: `DELETE /api/orders/{id}`  
   **Exemplo de chamada com curl**:
   ```bash
   curl -X DELETE http://localhost:5000/api/orders/123e4567-e89b-12d3-a456-426614174000
   ```

### 6. **Filtrar pedidos**
   **Endpoint**: `GET /api/orders/filter`  
   **Parâmetros de consulta (query)**:
   - `NomeCliente`: Nome do cliente para filtrar (opcional).
   - `startDate`: Data inicial do intervalo (opcional).
   - `endDate`: Data final do intervalo (opcional).
   **Exemplo de chamada com curl**:
   ```bash
   curl -X GET "http://localhost:5000/api/orders/filter?NomeCliente=João&startDate=2024-01-01&endDate=2024-01-31"
   ```

---

## 📀 Notas Finais
- Certifique-se de que o ambiente local está configurado corretamente.
- Para dúvidas ou problemas, abra uma issue no repositório do GitHub.

---

