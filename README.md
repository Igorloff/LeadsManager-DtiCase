# Leads Manager – DTI Case
## 📌 Sobre o Projeto

***Este projeto foi desenvolvido como solução para o desafio técnico Full Stack .NET. <br>
O objetivo é construir uma aplicação de gerenciamento de leads para uma empresa, composta por: <br>
Backend: API RESTful em .NET 6 (C#) com Entity Framework Core e SQL Server. <br>
Frontend: Aplicação SPA em React.<br>
Banco de Dados: SQL Server (local).<br>
Testes Unitários: Implementados com xUnit, Vitest e Testing library.*** 

# 🛠️ Tecnologias Utilizadas

## Backend:
+ .NET 6 / C#
+ Entity Framework Core
+ SQL Server
+ MediatR (CQRS)
+ xUnit para testes
+ Fake Email Service (gera log em arquivo email_log.txt)

## Frontend:
+ React
+ Vite
+ Axios para consumo da API
+ Css module

## 📧 Notificação por E-mail
O envio de e-mails foi simulado. <br>
Cada aceitação de lead gera um log em backend/email_log.txt. <br>

## 📖 Critérios Atendidos
✅ API .NET Core 6 RESTful <br>
✅ SPA em React <br>
✅ Banco SQL Server com EF Core <br>
✅ Testes Unitários <br>
✅ CQRS com MediatR <br>
✅ Serviço de notificação fake <br>


## 1️⃣ Configurar o Banco de Dados
No arquivo `backend/appsettings.json`, ajuste a connection string se necessário:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Leads;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## 2️⃣ Rodar o Backend
```
cd backend
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run build
```
Para criar novos Leads, basta acessar no navegador `http://localhost:SUA-PORTA/swagger/index.html` e acessar POST /api/Leads. <br>

## 3️⃣ Rodar o Frontend
```
cd frontend
npm install
npm run dev
```
Para vizualizar a interface, basta acessar no navegador `http://localhost:SUA-PORTA` ou pressionar 'o' no terminal após o comando `npm run dev`. <br>

## Para rodar os testes unitários:

### Frontend: ( Funcional )
```
cd frontend
npm test
```

### Backend: ( Não tive tempo de configurar corretamente 😓 )
```
cd Backend.Tests
dotnet test
```

## 🖼️ Screenshots
### Aba Invited
<img width="1914" height="904" alt="Captura de tela 2025-09-21 223225" src="https://github.com/user-attachments/assets/49233f5a-306e-4dbb-aa8e-ca0cb39d8e14" />



### Aba Accepted
<img width="1897" height="904" alt="Captura de tela 2025-09-21 223353" src="https://github.com/user-attachments/assets/ba351c01-1762-47a3-9389-a7135dfe52b8" />



### 🔹 Autor: Igor Reis
### 🔹 Desafio: DTI - Full Stack .NET Case
