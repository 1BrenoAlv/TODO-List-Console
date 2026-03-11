using TaskSuppy.Services.Interface;

namespace TaskSuppy.Menu.MenuOpcoes
{
    class MenuExcluirTarefa
    {
        public static async Task ExcluirTarefa()
        {
            //var context = new AppDbContext();
            //TarefaService tarefaService = new TarefaService(context);
            ITarefaService tarefaService = DependencyInjection.Dependencias();
            var tarefa = await tarefaService.ListarTarefas();

            if (tarefa.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Lista de Tarefas Vazia!!");
                await Task.Delay(1500);
            }
            else
            {
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
                    bool verifId = tarefa.Any(i => i.Id == id);
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
}
