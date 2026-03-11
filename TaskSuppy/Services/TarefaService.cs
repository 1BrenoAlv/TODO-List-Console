using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TaskSuppy.Db;
using TaskSuppy.Entities;
using TaskSuppy.Services.Interface;

namespace TaskSuppy.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext dbConnection)
        {
            _context = dbConnection;
        }


        public async Task<List<Tarefa>> ListarTarefas()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Buscando dados...");
                Task.Delay(1000).Wait();
                Console.Clear();
                var tarefas = await _context.Tarefa.ToListAsync();
                return tarefas;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao listar tarefas :" + e.Message, e);
            }
        }
        public void CriarTarefa(Tarefa tarefa)
        {
            try
            {
                _context.Tarefa.Add(tarefa);
                if (tarefa != null)
                {
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao criar tarefa: " + e.Message);
            }
        }

        public void EditarTarefa(Tarefa tarefa)
        {
            try
            {
                int id = tarefa.Id;
                var tarefaEdit = _context.Tarefa.FirstOrDefault(e => e.Id == id);
                if (tarefaEdit != null)
                {
                    tarefaEdit.Titulo = tarefa.Titulo;
                    tarefaEdit.Descricao = tarefa.Descricao;
                    tarefaEdit.HoraEstimada = tarefa.HoraEstimada;
                    _context.SaveChanges();
                }
            }

            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao editar tarefa: " + e.Message);
            }
        }

        public void DeletarTarefa(int id)
        {
            try
            {
                var tarefaExcluir = _context.Tarefa.FirstOrDefault(i => i.Id == id);
                if (tarefaExcluir != null)
                {
                    _context.Tarefa.Remove(tarefaExcluir);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tentar deletar tarefa: " + e.Message);
            }
        }

        public void AlterarStatus(Tarefa tarefa)
        {
            try
            {
                int id = tarefa.Id;
                var tarefaStatus = _context.Tarefa.FirstOrDefault(i => i.Id == id);
                if (tarefaStatus != null)
                {
                    tarefaStatus.StatusTarefa = tarefa.StatusTarefa;
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao Alterar Status da tarefa: " + e.Message);
            }
        }

        public void PegarTarefa(int id)
        {
            try
            {
                var pegarTarefa = _context.Tarefa.FirstOrDefault(p => p.Id == id);
                if (pegarTarefa != null)
                {
                    Console.WriteLine($"===============Tarefa N°{pegarTarefa.Id}================\n\n" +
                  $"Titulo: {pegarTarefa.Titulo}\n" +
                  $"Conteúdo: {pegarTarefa.Descricao}\n" +
                  $"Status: {pegarTarefa.StatusTarefa}\n" +
                  $"Data Criação: {pegarTarefa.DataCriacao}\n" +
                  (pegarTarefa.HoraEstimada != null ? $"Horas Estimada: {pegarTarefa.HoraEstimada}\n" : ""));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao pegar tarefa: " + e.Message);
            }
        }
    }
}
