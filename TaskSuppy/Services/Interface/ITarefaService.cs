using TaskSuppy.Entities;

namespace TaskSuppy.Services.Interface
{
    public interface ITarefaService
    {
        void CriarTarefa(Tarefa tarefa);
        void EditarTarefa(Tarefa tarefa);
        void DeletarTarefa(int id);
        Task<List<Tarefa>> ListarTarefas();
        void AlterarStatus(Tarefa tarefa);
        void PegarTarefa(int id);
    }
}
