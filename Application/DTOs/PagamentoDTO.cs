using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagamentoDTO
    {
        public int Id { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? NomeAluno { get; set; }
        public string? DataPagamentoFormatada { get; set; }

        public int? AlunoId { get; set; }
        public int? PlanoId { get; set; }
        public string? NomePlano { get; set; }
    }
}
