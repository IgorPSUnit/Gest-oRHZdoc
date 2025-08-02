# 🗄️ Configuração do Banco de Dados - RHZDOC

Este guia detalha como configurar o banco de dados para o sistema RHZDOC.

## 📋 Pré-requisitos

- SQL Server LocalDB ou SQL Server Express/Developer
- .NET 8.0 SDK
- Entity Framework Tools

## 🚀 Instalação do SQL Server LocalDB

### Windows

1. **Baixe o SQL Server LocalDB**:
   - Acesse: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
   - Baixe "SQL Server Express LocalDB"

2. **Instale o LocalDB**:
   ```bash
   # Execute o instalador baixado
   # Ou use o comando (se disponível):
   sqllocaldb install "MSSQLLocalDB"
   ```

3. **Inicie o LocalDB**:
   ```bash
   sqllocaldb start "MSSQLLocalDB"
   ```

### Verificar Instalação

```bash
# Verificar se o LocalDB está rodando
sqllocaldb info "MSSQLLocalDB"

# Conectar via SQLCMD (se instalado)
sqlcmd -S "(localdb)\MSSQLLocalDB"
```

## 🔧 Configuração do Projeto

### 1. String de Conexão

A string de conexão está configurada em `Data/GestaoRHContext.cs`:

```csharp
private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RHZDOC;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
```

### 2. Instalar Entity Framework Tools

```bash
# Instalar globalmente
dotnet tool install --global dotnet-ef

# Verificar instalação
dotnet ef --version
```

## 🗄️ Criar o Banco de Dados

### Opção 1: Usando Entity Framework (Recomendado)

```bash
# Navegar para o diretório do projeto
cd GestãoRHZdoc

# Criar a migration inicial
dotnet ef migrations add InitialCreate

# Aplicar a migration e criar o banco
dotnet ef database update
```

### Opção 2: Usando SQL Server Management Studio

1. **Conectar ao LocalDB**:
   - Server name: `(localdb)\MSSQLLocalDB`
   - Authentication: Windows Authentication

2. **Criar o banco de dados**:
   ```sql
   CREATE DATABASE RHZDOC;
   GO
   ```

3. **Verificar se foi criado**:
   ```sql
   USE RHZDOC;
   GO
   SELECT name FROM sys.tables;
   ```

### Opção 3: Usando SQLCMD

```bash
# Conectar ao LocalDB
sqlcmd -S "(localdb)\MSSQLLocalDB"

# Criar o banco
CREATE DATABASE RHZDOC;
GO

# Verificar
SELECT name FROM sys.databases WHERE name = 'RHZDOC';
GO
```

## 📊 Estrutura das Tabelas

Após a criação, o banco terá as seguintes tabelas:

### Tabela Funcionario
```sql
CREATE TABLE [Funcionario] (
    [Id] int NOT NULL IDENTITY(1,1),
    [Nome] nvarchar(max) NOT NULL,
    [Cargo] nvarchar(max) NOT NULL,
    [DataDeAdmissao] datetime2 NOT NULL,
    [Salario] decimal(18,2) NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY ([Id])
);
```

### Tabela Ferias
```sql
CREATE TABLE [Ferias] (
    [IdFerias] int NOT NULL IDENTITY(1,1),
    [IdFuncionario] int NOT NULL,
    [DataInicio] datetime2 NULL,
    [DataTermino] datetime2 NULL,
    CONSTRAINT [PK_Ferias] PRIMARY KEY ([IdFerias]),
    CONSTRAINT [FK_Ferias_Funcionario_IdFuncionario] FOREIGN KEY ([IdFuncionario]) REFERENCES [Funcionario] ([Id]) ON DELETE CASCADE
);
```

## 🔍 Verificar Configuração

### 1. Testar Conexão

```bash
# Executar o projeto
dotnet run

# Se não houver erros de conexão, está funcionando
```

### 2. Verificar Tabelas

```sql
USE RHZDOC;
GO

-- Listar tabelas
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE';

-- Verificar estrutura da tabela Funcionario
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Funcionario';

-- Verificar estrutura da tabela Ferias
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Ferias';
```

## 🛠️ Migrations

### Criar Nova Migration

```bash
# Após alterar os modelos
dotnet ef migrations add NomeDaAlteracao
```

### Aplicar Migrations

```bash
# Aplicar todas as migrations pendentes
dotnet ef database update

# Aplicar até uma migration específica
dotnet ef database update NomeDaMigration
```

### Reverter Migration

```bash
# Reverter uma migration
dotnet ef database update NomeDaMigrationAnterior

# Remover migration não aplicada
dotnet ef migrations remove
```

### Listar Migrations

```bash
# Ver todas as migrations
dotnet ef migrations list

# Ver migrations aplicadas no banco
dotnet ef database update --verbose
```

## 🐛 Solução de Problemas

### Erro: "Cannot open database"

```bash
# Verificar se o LocalDB está rodando
sqllocaldb info "MSSQLLocalDB"

# Se não estiver, iniciar
sqllocaldb start "MSSQLLocalDB"
```

### Erro: "Login failed"

1. **Verificar autenticação Windows**
2. **Verificar permissões do usuário**
3. **Usar SQL Server Authentication** (se necessário):

```csharp
// Modificar string de conexão
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RHZDOC;User Id=sa;Password=sua_senha;"
```

### Erro: "Entity Framework Tools not found"

```bash
# Reinstalar EF Tools
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
```

### Erro: "Migration already exists"

```bash
# Remover pasta Migrations
rm -rf Migrations/

# Recriar migration inicial
dotnet ef migrations add InitialCreate
```

## 🔄 Backup e Restore

### Backup

```sql
BACKUP DATABASE RHZDOC 
TO DISK = 'C:\Backup\RHZDOC.bak'
WITH FORMAT, INIT, NAME = 'RHZDOC-Full Database Backup';
```

### Restore

```sql
RESTORE DATABASE RHZDOC 
FROM DISK = 'C:\Backup\RHZDOC.bak'
WITH REPLACE;
```

## 📝 Notas Importantes

1. **LocalDB é para desenvolvimento**: Não use em produção
2. **Backup regular**: Faça backup dos dados importantes
3. **Migrations**: Sempre use migrations para alterações no banco
4. **Versionamento**: Mantenha as migrations no controle de versão

## 🔗 Links Úteis

- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) 