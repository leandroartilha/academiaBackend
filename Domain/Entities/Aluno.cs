using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Aluno
    {
        [STAThread]
        static void Main()
        {
        }
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string Nome { get; set; }
        
        [StringLength(11)]
        public string? Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DataUltimoPagamento { get; set; }

        public int? PlanoId { get; set; }
        public Plano? Plano { get; set; }

        public int? StatusPagamentoId { get; set; }
        public StatusPagamento? StatusPagamento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DataCadastro { get; set; }

        [StringLength(80)]
        public string? Enredeco { get; set; }

        [StringLength(15)]
        public string? Telefone { get; set; }

        [StringLength(15)]
        public string? Celular { get; set; }

        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}
