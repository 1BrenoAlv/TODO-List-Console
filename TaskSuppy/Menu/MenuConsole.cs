namespace TaskSuppy.Menu
{
    class MenuConsole
    {
        public  static void ShowMenu()
        {
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
            Console.WriteLine("  0 - Encerrar");
            Console.WriteLine("--------------------------------------");
            Console.Write("Escolha uma opção: ");
            int escolha = int.Parse(Console.ReadLine());
        }
    }
}
