using TaskSuppy.Db;
using TaskSuppy.Menu.MenuOpcoes;
using TaskSuppy.Services;

namespace TaskSuppy.Menu
{
    class MenuConsole
    {
        public static async Task ShowMenu()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
          _____  _    ____  _  __     ____  _   _ ____  ______   __
         |_   _|/ \  / ___|| |/ /    / ___|| | | |  _ \|  _ \ \ / /
           | | / _ \ \___ \| ' / ____\___ \| | | | |_) | |_) \ V / 
           | |/ ___ \ ___) | . \|_____|___) | |_| |  __/|  __/ | |  
           |_/_/   \_\____/|_|\_\    |____/ \___/|_|   |_|    |_|  
        ");

                Console.WriteLine("======================================");
                Console.WriteLine("                MENU                  ");
                Console.WriteLine("======================================");
                Console.WriteLine("  1 - Criar Tarefa");
                Console.WriteLine("  2 - Editar Tarefa");
                Console.WriteLine("  3 - Excluir Tarefa");
                Console.WriteLine("  4 - Listar Tarefas");
                Console.WriteLine("  5 - Alterar Status da Tarefa");
                Console.WriteLine("  6 - Filtrar Tarefas");
                Console.WriteLine("  0 - Encerrar");
                Console.WriteLine("--------------------------------------");
                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine()!;
                    if (escolha == "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Encerrando....");
                        await Task.Delay(1500);
                        return;
                    }
                    switch (escolha)
                    {

                        case "1":
                            MenuCriarTarefa.CriarTarefa();
                            break;
                        case "2":
                            Console.Clear();
                            await MenuEditarTarefa.EditarTarefa();
                            break;
                        case "3":
                            Console.Clear();
                            await MenuExcluirTarefa.ExcluirTarefa();
                            break;
                        case "4":
                            var tarefa = await tarefaService.ListarTarefas();
                            if (tarefa.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Lista de Tarefas Vazia!!");
                                await Task.Delay(1500);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("======================================");
                                Console.WriteLine("           Lista de Tarefas!          \n");
                                foreach (var lista in tarefa)
                                {
                                    Console.WriteLine(lista);
                                }
                                Console.WriteLine("======================================");
                            }

                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            await MenuAlterarStatusTarefa.AlterarStatusTarefa();
                            break;
                        case "6":
                            await MenuLinq.ConsultaCategoriaTarefa();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida!\nTente Novamente!!");
                            await Task.Delay(1500);
                            Console.Clear();
                            break;
                    }
            }
        }
    }
}
