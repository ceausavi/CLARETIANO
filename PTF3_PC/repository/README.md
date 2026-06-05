# 📋 Projeto banco_repository1

## Cadastro de Clientes com Padrão Repository

Projeto completo em C# com Windows Forms usando o padrão Repository para acesso a banco de dados MySQL.

---

## ⚡ Quick Start

### 1️⃣ Configurar o Banco de Dados

1. Abra o **MySQL Workbench**
2. Copie o conteúdo de `script_banco_mysql.sql`
3. Execute no MySQL Workbench

### 2️⃣ Abrir no Visual Studio

1. Abra o Visual Studio 2026
2. Selecione **File → Open → Project/Solution**
3. Navegue até a pasta `banco_repository1`
4. Selecione `banco_repository1.sln`

### 3️⃣ Instalar Dependências

1. **Tools → NuGet Package Manager → Package Manager Console**
2. Execute: `Install-Package MySql.Data -Version 8.0.33`

### 4️⃣ Executar

- Pressione **F5** ou **Debug → Start Debugging**

---

## 📁 Estrutura do Projeto

```
banco_repository1/
├── Cliente.cs                 # Modelo de dados
├── ClienteRepository.cs       # Acesso ao banco (CRUD)
├── Form1.cs                   # Formulário (lógica)
├── Form1.Designer.cs          # Formulário (design)
├── Form1.resx                 # Recursos do formulário
├── Program.cs                 # Ponto de entrada
├── App.config                 # Configuração
├── Properties/
│   └── AssemblyInfo.cs       # Info do assembly
├── bin/                       # Compilados
├── obj/                       # Objetos intermediários
├── packages.config            # Dependências NuGet
├── banco_repository1.csproj   # Arquivo do projeto
├── banco_repository1.sln      # Arquivo da solução
└── script_banco_mysql.sql     # Script do banco
```

---

## 🎨 Funcionalidades do Formulário

| Botão | Função |
|-------|--------|
| **Salvar** | Insere novo cliente no banco |
| **Buscar** | Busca cliente por ID |
| **Atualizar** | Modifica dados do cliente |
| **Deletar** | Remove cliente do banco |
| **Limpar** | Limpa todos os campos |

---

## ⚙️ Configuração da String de Conexão

No arquivo `App.config`:

```xml
<connectionStrings>
    <add name="MySQLConnectionString" 
         connectionString="Server=localhost;Database=banco_clientes;Uid=root;Pwd=root;Connect Timeout=30;" />
</connectionStrings>
```

**Altere conforme sua configuração MySQL:**
- `Server`: Endereço do servidor
- `Database`: Nome do banco
- `Uid`: Usuário MySQL
- `Pwd`: Senha MySQL

---

## 🏗️ Padrão Repository

O projeto implementa o **padrão Repository** que:

- ✅ Separa lógica de dados da interface
- ✅ Facilita testes unitários
- ✅ Permite trocar banco de dados facilmente
- ✅ Melhora manutenibilidade

---

## 🐛 Troubleshooting

### Erro de Conexão
- [ ] MySQL está rodando?
- [ ] Usuário e senha corretos em `App.config`?
- [ ] Banco de dados existe?

### Erro de Namespace
- [ ] Certificar que namespaces estão corretos
- [ ] Fazer rebuild do projeto (Ctrl + Shift + B)

### DLL não encontrada
- [ ] Instalar MySql.Data via NuGet
- [ ] Fazer Clean e Rebuild

---

## 📝 Notas

- Framework: **.NET Framework 4.7.2**
- Banco: **MySQL 8.0+**
- Connector: **MySql.Data 8.0.33**

---

**Desenvolvido com ❤️ para aprender padrões de arquitetura em C#**
