using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        AppDbContext _context;

        public PagamentoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pagamento> CreatePagamento(Pagamento pagamento)
        {
            var aluno = _context.Alunos.Where(a => a.Id == pagamento.AlunoId).FirstOrDefault();
            if(aluno != null)
            {
                _context.Pagamentos.Add(pagamento);
                await _context.SaveChangesAsync();
            }
            return pagamento;
        }

        public async Task<List<Pagamento>> GetAllPagamentos()
        {
            var pagamentos = await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .OrderByDescending(p => p.DataPagamento)
                .ToListAsync();
            return pagamentos;
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentosByAluno(int id)
        {
            return await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .Where(p => p.AlunoId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentosByData(DateTime date)
        {
            return await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .Where(p => p.DataPagamento == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentosByMes(int mes)
        {
            return await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .Where(p => p.DataPagamento.Value.Month == mes)
                .ToListAsync();
        }
    }
}
