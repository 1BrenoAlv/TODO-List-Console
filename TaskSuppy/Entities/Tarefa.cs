using System.Collections.Generic;
using TaskSuppy.Entities.Enum;

namespace TaskSuppy.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Status StatusTarefa { get; set; } = Status.PENDENTE;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public TimeSpan? HoraEstimada { get; set; } // Para saber quantas horas ela deve ser concluida
        private static int _contadorId = 0;

        public Tarefa(int id, string titulo, string descricao, TimeSpan? horaEstimada)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            HoraEstimada = horaEstimada;
        }
        public Tarefa(int id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }

        public Tarefa(string titulo, string descricao, TimeSpan? horaEstimada)
        {
            Id = Interlocked.Increment(ref _contadorId);
            Titulo = titulo;
            Descricao = descricao;
            HoraEstimada = horaEstimada;
        }
        public Tarefa(string titulo, string descricao)
        {
            Id = Interlocked.Increment(ref _contadorId);
            Titulo = titulo;
            Descricao = descricao;
        }

        public Tarefa(int id,Status status)
        {
            Id = id;
            StatusTarefa = status;
        }

        public override string ToString()
        {
            return $"===============Tarefa #{Id}================\n\n" +
                   $"Titulo: {Titulo}\n" +
                   $"Conteúdo: {Descricao}\n" +
                   $"Status: {StatusTarefa}\n" +
                   $"Data Criação: {DataCriacao}\n" +
                   (HoraEstimada != null ? $"Horas Estimada: {HoraEstimada}\n" : "");
        }
    }
}
