using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pagamento
    {
        public Pagamento() 
        {
        }

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double? Valor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        public int? AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        public int? PlanoId { get; set; }
        public Plano? Plano { get; set; }

    }
}
