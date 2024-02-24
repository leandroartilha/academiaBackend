using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno>GetAluno(int id);
        Task<List<Aluno>>GetAllAlunos();
        Task<Aluno>CreateAluno(Aluno aluno);
        Task<Aluno>UpdateAluno(Aluno aluno);
        Task<Aluno>DeleteAluno(int id);
        void AlterarUltimoPagamento(int? id);
        int CalcularStatus(DateTime data);
    }
}
