using TaskSuppy.Db;
using TaskSuppy.Services;
using TaskSuppy.Services.Interface;

namespace TaskSuppy
{
    public class DependencyInjection
    {
      public static ITarefaService Dependencias()
        {
            var context = new AppDbContext();
            ITarefaService tarefaService = new TarefaService(context);
            return tarefaService;
        }
    }
}
