# Calculadora de IMC (Índice de Massa Corporal)

Aplicação desktop desenvolvida em **C# Windows Forms** (.NET) para o cálculo do **Índice de Massa Corporal (IMC)** e respetiva classificação de acordo com os padrões da Organização Mundial da Saúde (OMS).

---

## 📸 Demonstração da Interface

![Interface da Calculadora de IMC](screenshot.png)

---

## ✨ Funcionalidades

- **Cálculo do IMC:** Aplica a fórmula padrão dividindo o peso pelo quadrado da altura ($\text{IMC} = \frac{\text{peso}}{\text{altura}^2}$).
- **Validação Segura de Dados:** Utiliza conversão segura (`double.TryParse`), aceitando valores decimais tanto com vírgula (`,`) quanto com ponto (`.`).
- **Classificação Automática:** Identifica a categoria correspondente ao IMC obtido.

---

## 📊 Tabela de Classificação do IMC (OMS)

| Faixa de IMC (kg/m²) | Classificação |
| :--- | :--- |
| Abaixo de 18,5 | Abaixo do peso |
| 18,5 a 24,9 | Peso normal |
| 25,0 a 29,9 | Sobrepeso |
| 30,0 a 34,9 | Obesidade grau I |
| 35,0 a 39,9 | Obesidade grau II |
| 40,0 ou superior | Obesidade grau III |

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 10.0 Windows Forms)
- **Framework:** Windows Desktop SDK (`Microsoft.NET.Sdk`)
- **IDE:** Visual Studio / Visual Studio Code

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) ou Visual Studio com suporte a C# / Windows Forms.

### Linha de Comandos (.NET CLI)
```bash
dotnet run
```

### Visual Studio
Abra o ficheiro `IMC_Csharp.slnx` (ou `CalculadoraIMC.csproj`) e pressione **F5** (ou clique em **Iniciar**).

---

## 📁 Estrutura dos Ficheiros

```text
├── IMC_Csharp.slnx        # Ficheiro de solução do Visual Studio
├── CalculadoraIMC.csproj   # Ficheiro de configuração do projeto .NET Windows Forms
├── Program.cs             # Código-fonte principal com FormIMC e lógica de cálculo
├── README.md              # Documentação do projeto
├── screenshot.png         # Captura de ecrã da aplicação em funcionamento
├── form.jpg               # Imagem da interface
└── .gitignore             # Ficheiros ignorados pelo Git
```
