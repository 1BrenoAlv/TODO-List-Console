using TaskSuppy.Entities;

namespace TaskSuppy.Services.Interface
{
    public interface ITarefaService
    {
        void CriarTarefa(Tarefa tarefas);
        void EditarTarefa(Tarefa tarefas);
        void DeletarTarefa(int id);
        List<Tarefa> ListarTarefas();
    }
}
