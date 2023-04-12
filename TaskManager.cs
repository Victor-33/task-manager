using System;
using System.Collections.Generic;

class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }
}

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        Console.WriteLine("Bem-vindo ao seu gerenciador de tarefas!");
        Console.WriteLine("Digite 'help' para ver os comandos disponíveis.");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (input == "exit")
            {
                break;
            }
            else if (input == "help")
            {
                Console.WriteLine("Comandos disponíveis:");
                Console.WriteLine("add - Adiciona uma nova tarefa.");
                Console.WriteLine("list - Lista todas as tarefas.");
                Console.WriteLine("complete - Marca uma tarefa como completa.");
                Console.WriteLine("remove - Remove uma tarefa.");
                Console.WriteLine("exit - Sai do gerenciador de tarefas.");
            }
            else if (input == "add")
            {
                Task task = new Task();

                Console.Write("Nome da tarefa: ");
                task.Name = Console.ReadLine();

                Console.Write("Descrição da tarefa: ");
                task.Description = Console.ReadLine();

                Console.Write("Data de vencimento (dd/mm/aaaa): ");
                task.DueDate = DateTime.Parse(Console.ReadLine());

                task.IsComplete = false;

                tasks.Add(task);

                Console.WriteLine($"Tarefa '{task.Name}' adicionada com sucesso!");
            }
            else if (input == "list")
            {
                Console.WriteLine("Tarefas:");
                Console.WriteLine("Nome\t\t\tDescrição\t\t\t\tData de vencimento\t\tConcluída");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

                foreach (Task task in tasks)
                {
                    Console.WriteLine($"{task.Name}\t\t{task.Description}\t\t{task.DueDate.ToString("dd/MM/yyyy")}\t\t{(task.IsComplete ? "Sim" : "Não")}");
                }
            }
            else if (input == "complete")
            {
                Console.Write("Digite o nome da tarefa que você concluiu: ");
                string name = Console.ReadLine();

                Task task = tasks.Find(t => t.Name == name);

                if (task != null)
                {
                    task.IsComplete = true;
                    Console.WriteLine($"Tarefa '{name}' marcada como concluída!");
                }
                else
                {
                    Console.WriteLine($"Tarefa '{name}' não encontrada.");
                }
            }
            else if (input == "remove")
            {
                Console.Write("Digite o nome da tarefa que você quer remover: ");
                string name = Console.ReadLine();

                Task task = tasks.Find(t => t.Name == name);

                if (task != null)
                {
                    tasks.Remove(task);
                    Console.WriteLine($"Tarefa '{name}' removida com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Tarefa '{name}' não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Comando inválido. Digite 'help' para ver os comandos disponíveis.");
            }
        }

        Console.WriteLine("Obrigado por usar o gerenciador de tarefas! Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}
