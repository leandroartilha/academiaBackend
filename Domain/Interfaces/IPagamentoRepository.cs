using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> CreatePagamento(Pagamento pagamento);
        Task<List<Pagamento>> GetAllPagamentos();
        Task<IEnumerable<Pagamento>> GetPagamentosByMes(int mes);
        Task<IEnumerable<Pagamento>> GetPagamentosByAluno(int id);
        Task<IEnumerable<Pagamento>> GetPagamentosByData(DateTime date);

    }
}
