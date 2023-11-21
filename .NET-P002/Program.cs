using System;
using System.Collections.Generic;

class Tarefa
{
    public int Indice { get; set; }
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Concluida { get; set; }
}

class GerenciadorTarefas
{
    private List<Tarefa> tarefas;

    public GerenciadorTarefas()
    {
        tarefas = new List<Tarefa>();
    }

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

    public void MarcarTarefaComoConcluida(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice].Concluida = true;
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido!");
        }
    }

    public void ListarTarefasPendentes()
    {
        foreach (Tarefa tarefa in tarefas)
        {
            if (!tarefa.Concluida)
            {
                Console.WriteLine($"ID: {tarefa.Indice}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Data de Vencimento: {tarefa.DataVencimento}");
                Console.WriteLine();
            }
        }
    }

    public void ListarTarefasConcluidas()
    {
        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Concluida)
            {
                Console.WriteLine($"ID: {tarefa.Indice}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Data de Vencimento: {tarefa.DataVencimento}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa concluída!");
                Console.WriteLine();
            }
        }
    }

    public void ExcluirTarefa(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido!");
            Console.WriteLine();

        }
    }

    public void PesquisarTarefas(string palavraChave)
    {
        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Titulo.Contains(palavraChave) || tarefa.Descricao.Contains(palavraChave))
            {
                Console.WriteLine($"ID: {tarefa.Indice}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Data de Vencimento: {tarefa.DataVencimento}");
                Console.WriteLine();
            }
        }
    }

    public void ObterEstatisticas()
    {
        int tarefasConcluidas = 0;
        int tarefasPendentes = 0;
        DateTime tarefaMaisAntiga = DateTime.MaxValue;
        DateTime tarefaMaisRecente = DateTime.MinValue;

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Concluida)
            {
                tarefasConcluidas++;
            }
            else
            {
                tarefasPendentes++;
            }
            if (tarefa.DataVencimento < tarefaMaisAntiga)
            {
                tarefaMaisAntiga = tarefa.DataVencimento;
            }

            if (tarefa.DataVencimento > tarefaMaisRecente)
            {
                tarefaMaisRecente = tarefa.DataVencimento;
            }
        }

        Console.WriteLine($"Número de Tarefas Concluídas: {tarefasConcluidas}");
        Console.WriteLine($"Número de Tarefas Pendentes: {tarefasPendentes}");
        Console.WriteLine($"Tarefa Mais Antiga: {tarefaMaisAntiga}");
        Console.WriteLine($"Tarefa Mais Recente: {tarefaMaisRecente}");
        Console.WriteLine();
    }

    internal int ObterProximoId()
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();
        int ide = 0;

        while (true)
        {
            Console.WriteLine("Gerenciador de Tarefas");
            Console.WriteLine("1. Criar uma Tarefa");
            Console.WriteLine("2. Listar todas as Tarefas");
            Console.WriteLine("3. Marcar uma Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir uma Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas");
            Console.WriteLine("8. Obter Estatísticas");
            Console.WriteLine("9. Sair");

            Console.Write("Digite a opção desejada: ");
            string? opcao = Console.ReadLine();
            Console.WriteLine();

            
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o título da tarefa: ");
                    string? titulo = Console.ReadLine();
                    Console.WriteLine();                    

                    Console.Write("Digite a descrição da tarefa: ");
                    string? descricao = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Digite a data de vencimento da tarefa (dd/mm/aaaa): ");
                    string? dataVencimentoStr = Console.ReadLine();
                    DateTime dataVencimento = DateTime.ParseExact(dataVencimentoStr, "dd/MM/yyyy", null);
                    Console.WriteLine();

                    gerenciador.CriarTarefa(ide, titulo, descricao, dataVencimento);
                    Console.WriteLine("Tarefa criada com sucesso!");
                    Console.WriteLine();
                    ide++;
                    break;

                case "2":
                    gerenciador.ListarTodasTarefas();
                    break;

                case "3":
                    Console.Write("Digite o índice da tarefa que deseja marcar como concluída: ");
                    int indiceConcluida = int.Parse(Console.ReadLine());

                    gerenciador.MarcarTarefaComoConcluida(indiceConcluida);
                    Console.WriteLine("Tarefa marcada como concluída com sucesso!");
                    Console.WriteLine();
                    break;

                case "4":
                    gerenciador.ListarTarefasPendentes();
                    break;

                case "5":
                    gerenciador.ListarTarefasConcluidas();
                    break;

                case "6":
                    Console.Write("Digite o índice da tarefa que deseja excluir: ");
                    int indiceExcluir = int.Parse(Console.ReadLine());

                    gerenciador.ExcluirTarefa(indiceExcluir);
                    Console.WriteLine("Tarefa excluída com sucesso!");
                    Console.WriteLine();
                    break;

                case "7":
                    Console.Write("Digite a palavra-chave para pesquisar tarefas: ");
                    string palavraChave = Console.ReadLine();

                    gerenciador.PesquisarTarefas(palavraChave);
                    break;

                case "8":
                    gerenciador.ObterEstatisticas();
                    break;
                case "9":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida! Por favor, digite novamente.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}