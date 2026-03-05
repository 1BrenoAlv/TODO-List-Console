using TaskSuppy.Db;
using TaskSuppy.Services;

namespace TaskSuppy.Menu.MenuOpcoes
{
     class MenuExcluirTarefa
    {
       public static void ExcluirTarefa()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);

            Console.WriteLine("======================================");
            Console.WriteLine("           Exclua sua Tarefa!         ");
            Console.WriteLine("======================================");
            Console.Write("Digite o ID da tarefa: ");
            while (true)
            {
                string idExcluir = Console.ReadLine();
                if (!int.TryParse(idExcluir, out int id))
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
                Console.Write("Deseja Realmente Excluir essa tarefa? (S/N)");
                while (true)
                {
                    string escolhaExcluir = Console.ReadLine().ToLower();
                    if (escolhaExcluir == "s")
                    {
                        Console.Clear();
                        Console.WriteLine("Tarefa Excluida!!\n\n");
                        tarefaService.PegarTarefa(id);
                        Thread.Sleep(2000);
                        tarefaService.DeletarTarefa(id);
                        Console.Clear();
                        break;
                    }
                    else if (escolhaExcluir == "n")
                    {
                        break;
                    }
                    Console.Clear();
                    Console.Write("Digite uma opção valida!!\n" +
                        "Deseja Realmente Excluir essa tarefa? (S/N): ");
                }
                break;
            }
        }
    }
}
