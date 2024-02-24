using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public int? PlanoId { get; set; }
        public int? StatusPagamentoId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataUltimoPagamento { get; set; }
        public string? DataNascimentoFormatada { get; set; }
        public string? DataCadastroFormatada { get; set; }
        public string? DataUltimoPagamentoFormatada { get; set; }
        public int StatusAlunoPagamento { get; set; }
    }
}
