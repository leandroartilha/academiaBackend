using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FormaPagamento
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string? Nome { get; set; }
    }
}
