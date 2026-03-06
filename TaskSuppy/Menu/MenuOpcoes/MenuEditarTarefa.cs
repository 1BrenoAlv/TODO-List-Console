using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Services;

namespace TaskSuppy.Menu.MenuOpcoes
{
    public static class MenuEditarTarefa
    {
        public static async Task EditarTarefa()
        {
            var context = new AppDbContext();
            TarefaService tarefaService = new TarefaService(context);
            var tarefas = await tarefaService.ListarTarefas();

            if (tarefas.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Lista de Tarefas Vazia!!");
                await Task.Delay(1500);
            }
            else
            {
                try
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("           Edite sua Tarefa!          ");
                    Console.WriteLine("======================================");
                    Console.Write("Digite o ID da tarefa: ");
                    while (true)
                    {
                        string idEditar = Console.ReadLine();
                        if (!int.TryParse(idEditar, out int id))
                        {
                            Console.Clear();
                            Console.Write("Valor inválido! Digite apenas números: ");
                            continue;
                        }
                        bool verifId = tarefas.Any(i => i.Id == id); // Verifica existencia em listas de objetos (LINQ)
                        if (!verifId)
                        {
                            Console.Clear();
                            Console.WriteLine("Erro: Id não encontrado! Tente Novamente!!");
                            Console.Write("Digite o ID da tarefa novamente: ");
                            continue;
                        }

                        var tarefaAtual = tarefas.FirstOrDefault(i => i.Id == id);
                        {
                            string tituloNovo = tarefaAtual.Titulo;
                            string descricaoNova = tarefaAtual.Descricao;
                            TimeSpan? horaEstimadaNova = tarefaAtual.HoraEstimada;


                            while (true)
                            {
                                Console.Clear();
                                tarefaService.PegarTarefa(id);
                                Console.WriteLine("\n\n=====================================");
                                Console.WriteLine("O que você deseja alterar?");
                                Console.WriteLine("1 - Título");
                                Console.WriteLine("2 - Descrição");
                                Console.WriteLine("3 - Prazo / Hora Estimada");
                                Console.WriteLine("0 - Salvar e Voltar ao Menu Principal");
                                Console.WriteLine("=====================================");
                                Console.Write("Escolha uma opção: ");

                                string opcao = Console.ReadLine();
                                if (opcao == "0")
                                {
                                    if (string.IsNullOrWhiteSpace(tituloNovo) || string.IsNullOrWhiteSpace(descricaoNova))
                                    {
                                        Console.WriteLine("Dados não foram preenchidos corretamente!!\n");
                                        Console.WriteLine("Voltando ao menu principal....");
                                        await Task.Delay(3000);
                                        break;
                                    }
                                    tarefaService.EditarTarefa(new Tarefa(id, tituloNovo, descricaoNova, horaEstimadaNova));
                                    Console.Clear();
                                    break;
                                }
                                switch (opcao)
                                {
                                    case "1":
                                        Console.Write($"\nDigite o novo Título (ou aperte Enter para manter '{tituloNovo}'): ");
                                        string inputTitulo = Console.ReadLine();
                                        if (!string.IsNullOrWhiteSpace(inputTitulo))
                                        {
                                            tituloNovo = inputTitulo;
                                            Console.WriteLine("Novo título Salvo!");
                                        }
                                        await Task.Delay(1500);
                                        break;
                                    case "2":
                                        Console.Write($"\nDigite a nova descrição (ou aperte Enter para manter '{descricaoNova}'): ");
                                        string inputDescricao = Console.ReadLine();
                                        if (!string.IsNullOrWhiteSpace(inputDescricao))
                                        {
                                            descricaoNova = inputDescricao;
                                            Console.WriteLine("Nova descrição Salva!");
                                        }
                                        await Task.Delay(1500);
                                        break;
                                    case "3":
                                        if (horaEstimadaNova == null)
                                        {
                                            Console.WriteLine("Você não tem prazo estimado para essa tarefa!!\n");
                                            Console.Write("Deseja adicionar um prazo na sua tarefa? (S/N)");
                                            while (true)
                                            {
                                                string? prazo = Console.ReadLine()?.ToLower();
                                                if (prazo == "n")
                                                    break;
                                                else if (prazo == "s")
                                                {
                                                    Console.Write("Qual é a hora estimada para conclusão da tarefa? ");
                                                    while (true)
                                                    {
                                                        string horas = Console.ReadLine();
                                                        if (!string.IsNullOrWhiteSpace(horas) && !horas.Contains(":"))
                                                        {
                                                            horas += ":00";
                                                        }
                                                        if (TimeSpan.TryParse(horas, out TimeSpan horasEstimada))
                                                        {
                                                            horaEstimadaNova = horasEstimada;
                                                            Console.WriteLine("Hora adicionada com sucesso!");
                                                            await Task.Delay(1500);
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.Write("Formato de hora inválido! Por favor, use dois pontos (ex: 01:30): ");
                                                        }
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.Write("Opção Inálida! Tente novamente\nDeseja adicionar um prazo na sua tarefa? (S/N): ");

                                                }
                                            }


                                        }
                                        else
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("A sua hora estimada é " + horaEstimadaNova);
                                                Console.WriteLine("Escolha a sua opção:");
                                                Console.WriteLine("1 - Remover Hora Estimada");
                                                Console.WriteLine("2 - Alterar Hora Estimada");
                                                Console.WriteLine("0 - Sair e Manter Hora Estimada");
                                                string opcaoHora = Console.ReadLine()?.ToLower();
                                                if (opcaoHora == "0")
                                                {

                                                    break;
                                                }
                                                switch (opcaoHora)
                                                {
                                                    case "1":
                                                        if (horaEstimadaNova != null)
                                                        {
                                                            Console.WriteLine("Hora Estimada Removida!!");
                                                            await Task.Delay(1500);
                                                            horaEstimadaNova = null;
                                                            break;
                                                        }

                                                        break;
                                                    case "2":
                                                        Console.Write("Digite o novo prazo da Tarefa (ex: 01:30): ");
                                                        while (true)
                                                        {
                                                            string horas = Console.ReadLine();
                                                            if (!string.IsNullOrWhiteSpace(horas) && !horas.Contains(":"))
                                                            {
                                                                horas += ":00";
                                                            }
                                                            if (TimeSpan.TryParse(horas, out TimeSpan horasEstimada))
                                                            {
                                                                horaEstimadaNova = horasEstimada;
                                                                Console.WriteLine("Hora Alterada com Sucesso!");
                                                                await Task.Delay(1500);
                                                                Console.Clear();
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.Write("Formato de hora inválido! Por favor, use dois pontos (ex: 01:30): ");
                                                            }
                                                        }
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        Console.Write("\nOpção inválida! Escolha um número do menu: ");
                                        await Task.Delay(1500);
                                        break;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("Tarefa Editada!!");
                            await Task.Delay(2000);
                            Console.Clear();
                            break;
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Você Tentou digitar um valor não compativel!\nErro: " + e.Message);
                }
                catch (ArgumentNullException e) { Console.WriteLine("Tentativa de editar uma tarefa com valores nulos!\nErro: " + e.Message); }
            }
        }
    }
}
