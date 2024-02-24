using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMapeamentoManual
    {
        public List<PagamentoDTO> PagamentoToPagamentoDTO(List<Pagamento> listaPagamentos);
        public List<AlunoDTO> AlunoToAlunoDTO(List<Aluno> listaAlunos);
        public string ConverterData(DateTime? date);
    }
}
