# Leads Manager – DTI Case
## 📌 Sobre o Projeto

***Este projeto foi desenvolvido como solução para o desafio técnico Full Stack .NET.
O objetivo é construir uma aplicação de gerenciamento de leads para uma empresa, composta por:
Backend: API RESTful em .NET 6 (C#) com Entity Framework Core e SQL Server.
Frontend: Aplicação SPA em React.
Banco de Dados: SQL Server (local).
Testes Unitários: Implementados com xUnit.***

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

### Frontend: ( Funcional )
```
cd frontend
npm test
```

## Para rodar os testes unitários:
### Backend: ( Não tive tempo de configurar corretamente 😓 )
```
cd Backend.Tests
dotnet test
```

## 🖼️ Screenshots
### Aba Invited
<img width="1914" height="904" alt="Captura de tela 2025-09-21 223225" src="https://github.com/user-attachments/assets/49233f5a-306e-4dbb-aa8e-ca0cb39d8e14" />


### Aba Accepted
<img width="1864" height="1001" alt="Captura de tela 2025-09-21 223043" src="https://github.com/user-attachments/assets/32b3ac8e-02e2-45e0-b093-6fe6d4593c77" />



### 🔹 Autor: Igor Reis
### 🔹 Desafio: DTI - Full Stack .NET Case
