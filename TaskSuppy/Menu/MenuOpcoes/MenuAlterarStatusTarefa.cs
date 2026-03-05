using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Entities.Enum;
using TaskSuppy.Services;

namespace TaskSuppy.Menu.MenuOpcoes
{
    internal class MenuAlterarStatusTarefa
    {
        public static void AlterarStatusTarefa()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);

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
                bool verifId = tarefaService.ListarTarefas().Any(i => i.Id == id); // Verifica existencia em listas de objetos (LINQ)
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
                        "\n===========================\n"+
                        "Digite o nome do status da tarefa:");
                    string statusAlterar = Console.ReadLine().ToUpper();
                    if (!Enum.TryParse(statusAlterar, out Status status))
                    {
                        Console.Clear();
                        Console.Write("Valor inválido! Digite Exatamente o nome do status: ");
                        continue;
                    }

                    tarefaService.AlterarStatus(new Tarefa(id, status));
                    Console.WriteLine("Status Alterado para " + status + "!!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
                break;
            }
        }
    }
}
