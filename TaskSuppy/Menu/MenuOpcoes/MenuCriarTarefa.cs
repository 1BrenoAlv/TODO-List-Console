using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Services;

namespace TaskSuppy.Menu.MenuOpcoes
{
    public static class MenuCriarTarefa
    {
        public static void CriarTarefa()
        {
            try
            {
                var context = new AppDbContext();
                TarefaService tarefaService = new TarefaService(context);

                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("           Crie sua Tarefa!           \n");
                Console.WriteLine("                                      \n");
                Console.WriteLine("                     * => Obrigatório \n");
                Console.WriteLine("======================================");
                Console.Write("*Digite o Titulo: ");
                string titulo = Console.ReadLine()!;
                Console.Write("*Digite o Conteúdo da Tarefa: ");
                string descricao = Console.ReadLine()!;
                Console.Write("Vai ter prazo para conclusão? (S/N)");
                while (true)
                {
                    string continua = Console.ReadLine()?.ToLower()!;
                    if (continua == "n")
                    {
                        if (string.IsNullOrWhiteSpace(descricao) || string.IsNullOrWhiteSpace(titulo))
                        {
                            Console.WriteLine("Dados não foram preenchidos corretamente!!\n");
                            Console.WriteLine("Algum campo está vazio!!\n");
                            Console.WriteLine("Voltando ao menu principal....");
                            Thread.Sleep(3000);
                            break;
                        }
                        tarefaService.CriarTarefa(new Tarefa(titulo, descricao));
                        Console.Clear();
                        Console.WriteLine("Tarefa Criada!!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }
                    else if (continua == "s")
                    {
                        if (string.IsNullOrWhiteSpace(descricao) || string.IsNullOrWhiteSpace(titulo))
                        {
                            Console.Clear();
                            Console.WriteLine("Dados não foram preenchidos corretamente!!\n");
                            Console.WriteLine("Voltando ao menu principal....");
                            Thread.Sleep(3000);
                            break;
                        }
                        Console.Write("Qual é a hora estimada para conclusão da tarefa? ");
                        while (true)
                        {
                            string horas = Console.ReadLine()!;
                            if (!string.IsNullOrWhiteSpace(horas) && !horas.Contains(":"))
                            {
                                horas += ":00";
                            }
                            if (TimeSpan.TryParse(horas, out TimeSpan horasEstimada))
                            {
                                tarefaService.CriarTarefa(new Tarefa(titulo, descricao, horasEstimada));
                                Console.WriteLine("Nova Tarefa Criada!!");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Formato de hora inválido! Por favor, use dois pontos (ex: 01:30): ");
                            }
                        }
                        Console.WriteLine("Tarefa Criada!!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                    Console.Write("Opção Inválida!! Vai ter prazo para conclusão? (S/N): ");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Você Tentou digitar um valor não compativel!\nErro: " + e.Message);
            }
            catch (ArgumentNullException e) { Console.WriteLine("Tentativa de criar uma tarefa com valores nulos!\nErro: " + e.Message); }
        }
    }
}
