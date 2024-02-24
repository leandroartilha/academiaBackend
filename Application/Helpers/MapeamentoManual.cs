using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Helpers
{
    public class MapeamentoManual : IMapeamentoManual
    {
        public List<PagamentoDTO> PagamentoToPagamentoDTO(List<Pagamento> listaPagamentos)
        {
            return listaPagamentos.Select(p =>
            new PagamentoDTO()
            {
                Id = p.Id,
                Valor = p.Valor,
                DataPagamentoFormatada = ConverterData(p.DataPagamento),
                NomeAluno = p.Aluno?.Nome
            }).ToList();
        }

        public List<AlunoDTO> AlunoToAlunoDTO(List<Aluno> listaAlunos)
        {
            return listaAlunos.Select(p =>
            new AlunoDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                DataCadastroFormatada = ConverterData(p.DataCadastro),
                DataNascimentoFormatada = ConverterData(p.DataNascimento),
                DataUltimoPagamentoFormatada = ConverterData(p.DataUltimoPagamento),
                DataUltimoPagamento = p.DataUltimoPagamento,
                StatusPagamentoId = p.StatusPagamentoId
            }).ToList();
        }

        public string ConverterData(DateTime? date)
        {
            string dataFormatada = date?.ToString("dd/MM/yyyy") ?? "Sem Data";
            return dataFormatada;
        }
    }
}
