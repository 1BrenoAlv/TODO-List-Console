using TaskSuppy.Entities;
using TaskSuppy.Entities.Enum;
using TaskSuppy.Services;

namespace TaskSuppy.Menu
{
    class MenuConsole
    {
        public static void ShowMenu()
        {
            TarefaService tarefaService = new TarefaService();

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
                int escolha = int.Parse(Console.ReadLine());
                if (escolha == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Encerrando....");
                    Thread.Sleep(3000);
                    return;
                }
                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("======================================");
                        Console.WriteLine("           Crie sua Tarefa!           ");
                        Console.WriteLine("======================================");
                        Console.Write("Digite o Titulo: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Digite o Conteúdo da Tarefa: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Vai ter prazo para conclusão? (S/N)");
                        while (true)
                        {
                            string continua = Console.ReadLine()?.ToLower();
                            if (continua == "n")
                            {
                                if (string.IsNullOrWhiteSpace(descricao) || string.IsNullOrWhiteSpace(titulo))
                                {
                                    Console.WriteLine("Dados não foram preenchidos corretamente!!\n");
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
                                    string horas = Console.ReadLine();
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
                        break;
                    case 2:
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
                                bool verifId = tarefaService.ListarTarefas().Any(i => i.Id == id); // Verifica existencia em listas de objetos (LINQ)
                                if (!verifId)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Erro: Id não encontrado! Tente Novamente!!");
                                    Console.Write("Digite o ID da tarefa novamente: ");
                                    continue;
                                }

                                var tarefaAtual = tarefaService.ListarTarefas().FirstOrDefault(i => i.Id == id);
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
                                            Thread.Sleep(3000);
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
                                            Thread.Sleep(1500);
                                            break;
                                        case "2":
                                            Console.Write($"\nDigite a nova descrição (ou aperte Enter para manter '{descricaoNova}'): ");
                                            string inputDescricao = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(inputDescricao))
                                            {
                                                descricaoNova = inputDescricao;
                                                Console.WriteLine("Nova descrição Salva!");
                                            }
                                            Thread.Sleep(1500);
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
                                                                Thread.Sleep(1500);
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
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Console.Write("\nOpção inválida! Escolha um número do menu: ");
                                            Thread.Sleep(1500);
                                            break;
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("Tarefa Editada!!");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                            }
                        }

                        break;
                    case 3:
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
                        break;
                    case 4:
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
                    case 5:
                        if (tarefaService.ListarTarefas().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Tarefas Vazia!!");
                            Thread.Sleep(1000);
                            break;
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
                                Console.Write("\n1. Concluido\n2. Pendente\n3. Atrasado\nDigite o nome do status da tarefa:");
                                string statusAlterar = Console.ReadLine().ToUpper();
                                    if (!Enum.TryParse(statusAlterar, out Status status))
                                    {
                                        Console.Clear();
                                        Console.Write("Valor inválido! Digite Exatamente o nome do status: ");
                                        continue;
                                    }
                                    
                                    tarefaService.AlterarStatus(new Tarefa(id, status));
                                    Console.WriteLine("Status Alterado para "+status +"!!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                                }
                                break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
