using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSuppy.Entities.Enum;

namespace TaskSuppy.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Status StatusTarefa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? HoraEstimada { get; set; } // Para saber quantas horas ela deve ser concluida

        public Tarefa(int id, string titulo, string descricao, Status statusTarefa, DateTime dataCriacao, DateTime horaEstimada)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            StatusTarefa = statusTarefa;
            DataCriacao = dataCriacao;
            HoraEstimada = horaEstimada;
        }

        public Tarefa(int id, string titulo, string descricao, Status statusTarefa, DateTime dataCriacao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            StatusTarefa = statusTarefa;
            DataCriacao = dataCriacao;
        }
    }
}
