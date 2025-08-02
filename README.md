# 🏢 Sistema de Gestão de Recursos Humanos - RHZDOC

Um sistema completo de gestão de recursos humanos desenvolvido em C# com Entity Framework Core, permitindo o cadastro, consulta e gerenciamento de funcionários e suas férias.

## 📋 Índice

- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Como Usar](#como-usar)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuição](#contribuição)
- [Licença](#licença)

## ✨ Funcionalidades

- **Cadastro de Funcionários**: Registro completo com nome, cargo, salário e data de admissão
- **Consulta de Funcionários**: Visualização de todos os funcionários cadastrados
- **Gestão de Férias**: Registro e consulta de períodos de férias
- **Interface Console**: Menu interativo e intuitivo
- **Persistência de Dados**: Armazenamento em banco de dados SQL Server
- **Validações**: Tratamento de dados e validações de entrada

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0**: Framework de desenvolvimento
- **C#**: Linguagem de programação
- **Entity Framework Core 9.0.7**: ORM para acesso a dados
- **SQL Server**: Banco de dados relacional
- **Microsoft.Data.SqlClient 6.1.0**: Driver para SQL Server

## 📦 Dependências

### Pacotes NuGet

```xml
<PackageReference Include="Microsoft.Data.SqlClient" Version="6.1.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.7" />
```

### Versões do .NET

- **Target Framework**: .NET 8.0
- **Implicit Usings**: Habilitado
- **Nullable Reference Types**: Habilitado

## ⚙️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (LocalDB ou Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) ou [Visual Studio Code](https://code.visualstudio.com/)

## 🚀 Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/GestaoRHZdoc.git
cd GestaoRHZdoc
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Compile o projeto

```bash
dotnet build
```

### 4. Execute o projeto

```bash
dotnet run
```

## 🗄️ Configuração do Banco de Dados

### String de Conexão

O projeto está configurado para usar SQL Server LocalDB. A string de conexão está definida em `Data/GestaoRHContext.cs`:

```csharp
private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RHZDOC;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
```

### Criar o Banco de Dados

1. **Usando Entity Framework Tools**:
   ```bash
   dotnet ef database update
   ```

2. **Ou usando SQL Server Management Studio**:
   - Conecte ao LocalDB
   - Crie um banco de dados chamado `RHZDOC`

### Migrations (se necessário)

```bash
# Criar uma nova migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations
dotnet ef database update
```

## 🎮 Como Usar

### Menu Principal

Ao executar o projeto, você verá o menu principal:

```
Bem-vindo ao Sistema de Gestão de Recursos Humanos!
1. Cadastrar Funcionário
2. Mostrar Funcionários
-1. Sair

Escolha uma opção:
```

### Cadastrar Funcionário

1. Selecione a opção **1**
2. Digite o nome do funcionário
3. Informe o cargo
4. Digite o salário (use vírgula ou ponto como separador decimal)
5. Informe a data de admissão (formato: dd/MM/yyyy)

### Mostrar Funcionários

1. Selecione a opção **2**
2. Visualize todos os funcionários cadastrados com suas informações

### Sair do Sistema

1. Selecione a opção **-1**
2. O sistema será encerrado

## 📁 Estrutura do Projeto

```
GestãoRHZdoc/
├── Data/
│   ├── Connection.cs
│   ├── DAL.cs
│   ├── FuncionarioDAL.cs
│   ├── GestaoRHContext.cs
│   └── GlobalData.cs
├── Menu/
│   ├── Menu.cs
│   ├── MenuMostrarFerias.cs
│   ├── MenuMostrarFuncionarios.cs
│   ├── MenuRegistrarFerias.cs
│   ├── MenuRegistrarFuncionario.cs
│   └── MenuSair.cs
├── Modelos/
│   ├── Ferias.cs
│   ├── Funcionario.cs
│   └── HistoricoAlteracao.cs
├── Program.cs
└── GestãoRHZdoc.csproj
```

### Descrição dos Diretórios

- **Data/**: Camada de acesso a dados (DAL) e contexto do Entity Framework
- **Menu/**: Classes responsáveis pela interface do usuário
- **Modelos/**: Entidades do sistema (Funcionario, Ferias, etc.)
- **Program.cs**: Ponto de entrada da aplicação

## 🔧 Configurações Avançadas

### Alterar String de Conexão

Para usar um SQL Server diferente, edite o arquivo `Data/GestaoRHContext.cs`:

```csharp
private readonly string connectionString = "Server=seu-servidor;Database=RHZDOC;Trusted_Connection=true;";
```

### Configurações do Entity Framework

O projeto está configurado com:
- **Lazy Loading**: Habilitado com proxies
- **Cascade Delete**: Configurado para férias
- **Virtual Properties**: Para suporte ao lazy loading

## 🐛 Solução de Problemas

### Erro de Conexão com Banco

1. Verifique se o SQL Server LocalDB está instalado
2. Confirme se a string de conexão está correta
3. Execute: `sqllocaldb start`

### Erro de Compilação

1. Verifique se o .NET 8.0 SDK está instalado
2. Execute: `dotnet restore`
3. Execute: `dotnet clean && dotnet build`

### Erro de Migration

1. Delete a pasta `Migrations/` (se existir)
2. Execute: `dotnet ef migrations add InitialCreate`
3. Execute: `dotnet ef database update`

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

**Seu Nome**
- GitHub: [@seu-usuario](https://github.com/seu-usuario)
- LinkedIn: [Seu LinkedIn](https://linkedin.com/in/seu-perfil)

## 📞 Suporte

Se você encontrar algum problema ou tiver dúvidas:

1. Abra uma [Issue](https://github.com/seu-usuario/GestaoRHZdoc/issues)
2. Entre em contato: seu-email@exemplo.com

---

⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório! 