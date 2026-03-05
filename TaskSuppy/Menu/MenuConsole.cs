using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Entities.Enum;
using TaskSuppy.Menu.MenuOpcoes;
using TaskSuppy.Services;

namespace TaskSuppy.Menu
{
    class MenuConsole
    {
        public static void ShowMenu()
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
                Console.WriteLine("  0 - Encerrar");
                Console.WriteLine("--------------------------------------");
                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();
                if (escolha == "0")
                {
                    Console.Clear();
                    Console.WriteLine("Encerrando....");
                    Thread.Sleep(3000);
                    return;
                }
                switch (escolha)
                {
                    case "1":
                        MenuCriarTarefa.CriarTarefa();
                        break;
                    case "2":
                        Console.Clear();
                        if (tarefaService.ListarTarefas().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Tarefas Vazia!!");
                            Thread.Sleep(1500);
                            break;
                        }
                        else
                        {
                            MenuEditarTarefa.EditarTarefa();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        if (tarefaService.ListarTarefas().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Tarefas Vazia!!");
                            Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            MenuExcluirTarefa.ExcluirTarefa();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        if (tarefaService.ListarTarefas().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Tarefas Vazia!!");
                            Thread.Sleep(1500);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("======================================");
                            Console.WriteLine("           Lista de Tarefas!          ");
                            foreach (var lista in tarefaService.ListarTarefas())
                            {
                                Console.WriteLine(lista);
                            }
                        }

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        if (tarefaService.ListarTarefas().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Tarefas Vazia!!");
                            Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                           MenuAlterarStatusTarefa.AlterarStatusTarefa();
                        }
                        break;
                        default: Console.WriteLine("Opção Inválida!\nTente Novamente!!");
                        Thread.Sleep(1500);
                        Console.Clear();
                            break;
                }
            }
        }
    }
}
