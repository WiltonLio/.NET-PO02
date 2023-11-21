### Instrução Pratica .NET-P002

#### Objetivo:
>Desenvolver um sistema de gerenciamento de tarefas que permita aos usuários criar, visualizar e gerenciar tarefas.

#### Requisitos do Projeto:
>O sistema deve permitir a criação de tarefas, incluindo um título, descrição e data de vencimento.

![Criar Tarefa](<img/1 (1).png>)

```csharp
public void CriarTarefa(int indice, string titulo, string descricao, DateTime dataVencimento)
    {
        Tarefa novaTarefa = new Tarefa
        {
            Indice = indice,
            Titulo = titulo,
            Descricao = descricao,
            DataVencimento = dataVencimento,
            Concluida = false
        };

        tarefas.Add(novaTarefa);
    }
```

>Deve ser possível listar todas as tarefas criadas.

```csharp
public void ListarTodasTarefas()
    {
        foreach (Tarefa tarefa in tarefas)
        {
            Console.WriteLine($"ID: {tarefa.Indice}");
            Console.WriteLine($"Título: {tarefa.Titulo}");
            Console.WriteLine($"Descrição: {tarefa.Descricao}");
            Console.WriteLine($"Data de Vencimento: {tarefa.DataVencimento}");
            Console.WriteLine($"Concluída: {tarefa.Concluida}");
            Console.WriteLine();
        }
    }
```

>Os usuários devem poder marcar tarefas como concluídas.

```csharp

```

>O sistema deve fornecer uma lista de tarefas pendentes e uma lista de tarefas concluídas.

```csharp

```

>Os usuários devem ser capazes de excluir tarefas.

```csharp

```

>Implemente uma pesquisa que permita aos usuários encontrar tarefas com base em palavras-chave.

```csharp

```

>O sistema deve fornecer estatísticas básicas, como o número de tarefas concluídas e pendentes, a tarefa mais antiga e a tarefa mais recente.

```csharp

```