using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAlunoService
    {
        Task<AlunoDTO>GetAluno(int id);
        Task<List<AlunoDTO>>GetAllAlunos();
        Task<AlunoDTO>CreateAluno(AlunoDTO aluno);
        Task<AlunoDTO>UpdateAluno(AlunoDTO aluno);
        Task<AlunoDTO>DeleteAluno(int id);
    }
}