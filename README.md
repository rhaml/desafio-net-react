# 🎹 Escola de Música — Sistema de Gerenciamento de Estudantes

Sistema completo para gerenciamento de estudantes de uma escola de música.

O projeto possui:

* ✅ API REST em .NET 8
* ✅ React + Material UI
* ✅ JWT Authentication
* ✅ CRUD completo
* ✅ Busca e filtros
* ✅ Paginação server-side
* ✅ Responsivo
* ✅ Seed via CSV
* ✅ Swagger com autenticação

---

# 📦 Tecnologias

## Back-end

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* InMemory Database
* AutoMapper
* FluentValidation
* JWT Authentication
* Swagger
* Repository Pattern
* xUnit
* Moq

---

## Front-end

* React
* React Router DOM
* Axios
* Material UI
* MUI DataGrid
* Dayjs

---

# 📁 Estrutura do Projeto

```txt
Solution
│
├── DesafioApi
│   ├── Configurations
│   ├── Controller
│   ├── Data
│   ├── DTOs
│   ├── Mappers
│   ├── Models
│   ├── Repository
│   ├── Services
│   └── Program.cs
│
├── DesafioApi.Tests
│
└── desafio-api-front
```

---

# 🚀 Como executar o projeto

# 1️⃣ Clonar o projeto

```bash
git clone <url-do-repositorio>
```

---

# 2️⃣ Executar o Back-end

## 📂 Entrar na pasta

```bash
cd DesafioApi
```

---

## 📦 Restaurar dependências

```bash
dotnet restore
```

---

## ▶️ Executar API

```bash
dotnet run
```

---

# ✅ Swagger

Ao iniciar a API, o Swagger abrirá automaticamente.

Exemplo:

```txt
https://localhost:44377/swagger/index.html
```

---

# 🔐 Usuário padrão

```txt
Usuário: admin
Senha: Admin123!
```

---

# 📄 Seed de estudantes

Os estudantes são carregados automaticamente através do arquivo:

```txt
/Data/students.csv
```

---

# 3️⃣ Executar o Front-end

## 📂 Entrar na pasta

```bash
cd desafio-api-front
```

---

## 📦 Instalar dependências

```bash
npm install
```

---

## ▶️ Executar aplicação

```bash
npm start
```

---

# 🌐 Front-end

```txt
http://localhost:3000
```

---

# 🔑 Login

Use:

```txt
admin
Admin123!
```

---

# 🎨 Funcionalidades

## Autenticação

* Login JWT
* Proteção de rotas
* Logout

---

## Estudantes

* Listar estudantes
* Buscar por nome
* Paginação server-side
* Criar estudante
* Editar estudante
* Excluir estudante

---

## Interface

* Responsivo para mobile
* DataGrid 
* Cards no mobile
* Snackbar de feedback

---

# 🔐 Endpoints

## Auth

| Método | Endpoint          |
| ------ | ----------------- |
| POST   | /api/auth/login   |
| POST   | /api/auth/refresh |

---

## Students

| Método | Endpoint           |
| ------ | ------------------ |
| GET    | /api/students      |
| GET    | /api/students/{id} |
| POST   | /api/students      |
| PUT    | /api/students/{id} |
| DELETE | /api/students/{id} |

---

# 🧪 Executar testes

## 📂 Entrar na pasta

```bash
cd DesafioAPI.Tests
```

---

## ▶️ Rodar testes

```bash
dotnet test
```

---

# 📦 Principais pacotes utilizados

## Back-end

```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

dotnet add package FluentValidation.AspNetCore

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add package Swashbuckle.AspNetCore

dotnet add package CsvHelper
```

---

## Front-end

```bash
npm install @mui/material

npm install @mui/icons-material

npm install @mui/x-data-grid

npm install @mui/x-date-pickers

npm install axios

npm install react-router-dom

npm install dayjs
```

---

# 👨‍💻 Autor

Projeto desenvolvido para estudo e demonstração de arquitetura moderna com .NET 8 + React.
