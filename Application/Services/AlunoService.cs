using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _repository;
        private readonly IMapper _mapper;
        public IMapeamentoManual _mapeamentoManual;
        public AlunoService(IAlunoRepository repository, IMapper mapper, IMapeamentoManual mapeamentoManual)
        {
            _repository = repository;
            _mapper = mapper;
            _mapeamentoManual = mapeamentoManual;
        }
        public async Task<AlunoDTO> CreateAluno(AlunoDTO alunoDTO)
        {
            var alunoEntity = _mapper.Map<Aluno>(alunoDTO);
            alunoEntity.DataCadastro = DateTime.Now;
            alunoEntity.DataUltimoPagamento = new DateTime(1900, 01, 01, 00, 00, 00, 000);
            var alunoCriado = await _repository.CreateAluno(alunoEntity);

            return _mapper.Map<AlunoDTO>(alunoCriado);
        }

        public async Task<AlunoDTO> DeleteAluno(int id)
        {
            var alunoEntity = await _repository.DeleteAluno(id);
            return _mapper.Map<AlunoDTO>(alunoEntity);
        }

        public async Task<List<AlunoDTO>> GetAllAlunos()
        {
            var alunosEntity = await _repository.GetAllAlunos();
            var listaAlunosDTO = _mapeamentoManual.AlunoToAlunoDTO(alunosEntity);

            var alunosAtualizados = new List<AlunoDTO>();

            foreach (var item in listaAlunosDTO)
            {
                item.StatusAlunoPagamento = _repository.CalcularStatus((DateTime)item.DataUltimoPagamento);
                alunosAtualizados.Add(item);
            }

            return alunosAtualizados;
        }

        public async Task<AlunoDTO> GetAluno(int id)
        {
            var alunoEntity = await _repository.GetAluno(id);
            var alunoDTO = _mapper.Map<AlunoDTO>(alunoEntity);
            alunoDTO.StatusAlunoPagamento = _repository.CalcularStatus((DateTime)alunoDTO.DataUltimoPagamento);
            return alunoDTO;
        }

        public async Task<AlunoDTO> UpdateAluno(AlunoDTO alunoDTO)
        {
            var alunoEntity = _mapper.Map<Aluno>(alunoDTO);
            await _repository.UpdateAluno(alunoEntity);
            return _mapper.Map<AlunoDTO>(alunoEntity);
        }
    }
}
