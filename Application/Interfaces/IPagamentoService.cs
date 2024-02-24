using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<PagamentoDTO> CreatePagamento(PagamentoDTO pagamento);
        Task<List<PagamentoDTO>> GetAllPagamentos();
        Task<IEnumerable<PagamentoDTO>> GetPagamentosByMes(int mes);
        Task<IEnumerable<PagamentoDTO>> GetPagamentosByAluno(int id);
        Task<IEnumerable<PagamentoDTO>> GetPagamentosByData(DateTime date);
    }
}
