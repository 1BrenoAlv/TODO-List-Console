using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Entities.Enum;
using TaskSuppy.Services;

namespace TaskSuppy.Menu.MenuOpcoes
{
    internal class MenuAlterarStatusTarefa
    {
        public static async Task AlterarStatusTarefa()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);
            var tarefaList = await tarefaService.ListarTarefas();
            if (tarefaList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Lista de Tarefas Vazia!!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("      Alterar Status da sua Tarefa!   ");
                Console.WriteLine("======================================");
                Console.Write("Digite o ID da tarefa: ");
                while (true)
                {
                    string idAlterarStatus = Console.ReadLine();
                    if (!int.TryParse(idAlterarStatus, out int id))
                    {
                        Console.Clear();
                        Console.Write("Valor inválido! Digite apenas números: ");
                        continue;
                    }
                    bool verifId = tarefaList.Any(i => i.Id == id); // Verifica existencia em listas de objetos (LINQ)
                    if (!verifId)
                    {
                        Console.Clear();
                        Console.WriteLine("Erro: Id não encontrado! Tente Novamente!!");
                        Console.Write("Digite o ID da tarefa novamente: ");
                        continue;
                    }
                    tarefaService.PegarTarefa(id);
                    while (true)
                    {
                        Console.WriteLine("\n===========================\n");
                        Console.Write("\n1. Concluido\n2. Pendente\n3. Atrasado\n" +
                            "\n===========================\n" +
                            "Digite o nome do status da tarefa:");
                        string statusAlterar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(statusAlterar))
                        {
                            Console.WriteLine("Esse campo não pode ser vazio!\nTente Novamente!");
                            await Task.Delay(1000);
                            Console.Clear();
                            continue;
                        }
                        if (!Enum.TryParse(statusAlterar, true, out Status status) || !Enum.IsDefined(typeof(Status), status))
                        {
                            Console.Clear();
                            Console.Write("Valor inválido! Digite Exatamente o nome do status: ");
                            continue;
                        }
                        tarefaService.AlterarStatus(new Tarefa(id, status));
                        Console.Clear();
                        Console.WriteLine("\n===========================\n");
                        Console.WriteLine("Status Alterado para " + status + "!!");
                        Console.WriteLine("\n===========================\n");
                        await Task.Delay(1500);
                        Console.Clear();
                        break;
                    }
                    break;
                }
            }
        }
    }
}
