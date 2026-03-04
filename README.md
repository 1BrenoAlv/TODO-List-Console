# 📝 TaskSuppy

Um sistema de gerenciamento de tarefas (To-Do List) desenvolvido inteiramente em **C# (Console Application)**. 

O foco deste projeto é oferecer uma experiência de usuário (UX) fluida no terminal, com menus interativos, validações robustas contra erros de digitação e uma navegação à prova de falhas (sem loops infinitos ou quebras de sistema).

## 🚀 Funcionalidades

O sistema conta com um menu principal interativo contendo as seguintes operações (CRUD):

* **Criar Tarefa:** Permite adicionar um Título, Descrição e, opcionalmente, um Prazo/Hora Estimada de conclusão.
* **Editar Tarefa:** Conta com um *Submenu Inteligente*, permitindo alterar apenas o campo desejado (Título, Descrição ou Prazo) sem precisar reescrever a tarefa inteira.
* **Excluir Tarefa:** Busca por ID com validação de segurança antes da exclusão.
* **Listar Tarefas:** Exibe todas as tarefas cadastradas no sistema.
* **Alterar Status:** Modifica o estado atual da tarefa de forma dinâmica. O sistema aceita a digitação do nome do status, ignorando letras maiúsculas/minúsculas.
  * Status disponíveis: `Pendente`, `Concluido`, `Atrasado`.

## 🧠 Destaques Técnicos

Este projeto foi construído aplicando boas práticas de Programação Orientada a Objetos (POO) e manipulação de dados em C#:

* **Separação de Responsabilidades:** Código estruturado em pastas lógicas (`Entities`, `Enum`, `Services`, `Menu`).
* **Validação de Inputs:** Uso extensivo de `TryParse`, `string.IsNullOrWhiteSpace` e validações de manipulação de `string` (como `.Contains()`) para garantir que o sistema não quebre com dados inválidos.
* **Tratamento de Enums:** Uso de `Enum.TryParse` para converter entradas de texto do usuário diretamente para tipos enumerados de forma segura.
* **Consultas com LINQ:** Utilização de `.Any()` e `.FirstOrDefault()` para buscas rápidas e limpas na lista de tarefas.
* **Controle de Fluxo:** Gerenciamento avançado de loops `while` aninhados e cascatas de `break/continue` para navegação em submenus.

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C#
* **Plataforma:** .NET (Console Application)

## 💻 Como Executar o Projeto

1. Certifique-se de ter o [SDK do .NET](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório:
   ```bash
   git clone [https://github.com/SEU_USUARIO/TaskSuppy.git](https://github.com/SEU_USUARIO/TaskSuppy.git)
