using TaskSuppy.Db;
using TaskSuppy.Entities.Enum;
using TaskSuppy.Services;
using System.Linq;

namespace TaskSuppy.Menu.MenuOpcoes
{
    public class MenuLinq
    {
       public  static async Task ConsultaCategoriaTarefa()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);

            var tarefa = await tarefaService.ListarTarefas();

            Console.Write("Digite o status da lista: ");
            while (true)
            {
                string statusInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(statusInput))
                {
                    Console.WriteLine("Esse campo não pode ser vazio!\nTente Novamente!");
                    await Task.Delay(1000);
                    Console.Clear();
                    continue;
                }
                if (!Enum.TryParse(statusInput, true, out Status status) || !Enum.IsDefined(typeof(Status), status))
                {
                    Console.Clear();
                    Console.Write("Valor inválido! Digite Exatamente o nome do status: ");
                    
                    continue;
                }
                var consulta = tarefa.Where(t => t.StatusTarefa == status).ToList();
                if (consulta.Count == 0)
                {
                    Console.WriteLine($"\nNenhuma tarefa encontrada com o status '{status}'.");
                }
                else
                {
                    Console.WriteLine($"======================================");
                    Console.WriteLine($"      Tarefas com status: {status}    ");
                    Console.WriteLine($"======================================\n");
                    foreach (var lista in consulta)
                    {
                        Console.WriteLine($"Id Tarefa: {lista.Id}\n" +
                            $"Titulo Tarefa: {lista.Titulo}\n" +
                            $"======================================");
                    }
                }
                    break;
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}