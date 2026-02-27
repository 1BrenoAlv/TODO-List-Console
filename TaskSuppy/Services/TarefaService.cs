using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSuppy.Entities;
using TaskSuppy.Services.Interface;

namespace TaskSuppy.Services
{
    public class TarefaService : ITarefaService
    {
        private List<Tarefa> _tarefa = new List<Tarefa>();

        public TarefaService(List<Tarefa> tarefa)
        {
            _tarefa = tarefa;
        }

        public List<Tarefa> ListarTarefas()
        {
            return _tarefa;
        }
        public void CriarTarefa(Tarefa tarefas)
        {
            try
            {
                _tarefa.Add(tarefas);
            }
            catch (Exception e) { throw new Exception("Erro: " + e.Message); }
        }

        public void EditarTarefa(Tarefa tarefas)
        {
            string titulo = tarefas.Titulo;
            var tarefaEdit = _tarefa.FirstOrDefault(e => e.Titulo == titulo);
            if (tarefaEdit != null)
            {
                //TODO: Implementar crud 
            }


        }

        public void DeletarTarefa(int id)
        {
            try
            {
                var tarefaExcluir = _tarefa.FirstOrDefault(i => i.Id == id);
                if(tarefaExcluir != null) _tarefa.Remove(tarefaExcluir);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }


    }
}
