using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private IPagamentoRepository _pagamentoRepository;
        private IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        public IMapeamentoManual _mapeamentoManual;
        public PagamentoService(IPagamentoRepository pagamentoRepository,IAlunoRepository alunoRepository , IMapper mapper, IMapeamentoManual mapeamentoManual)
        {
            _pagamentoRepository = pagamentoRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _mapeamentoManual = mapeamentoManual;
        }
        public async Task<PagamentoDTO> CreatePagamento(PagamentoDTO pagamentoDTO)
        {
            try
            {
                var pagamentoEntity = _mapper.Map<Pagamento>(pagamentoDTO);
                pagamentoEntity.DataPagamento = DateTime.Now;

                var alunoId = pagamentoDTO.AlunoId;

                await _pagamentoRepository.CreatePagamento(pagamentoEntity);
                _alunoRepository.AlterarUltimoPagamento(alunoId);
                return pagamentoDTO;
            }
            catch (Exception ex)
            {
                return pagamentoDTO;
            }
        }

        public async Task<List<PagamentoDTO>> GetAllPagamentos()
        {
            List<Pagamento> pagamentos = await _pagamentoRepository.GetAllPagamentos();

            var listaPagamentosDTO = _mapeamentoManual.PagamentoToPagamentoDTO(pagamentos);

            return listaPagamentosDTO;
        }

        public async Task<IEnumerable<PagamentoDTO>> GetPagamentosByAluno(int id)
        {
            var pagamentos = await _pagamentoRepository.GetPagamentosByAluno(id);
            return _mapper.Map<IEnumerable<PagamentoDTO>>(pagamentos);
        }

        public async Task<IEnumerable<PagamentoDTO>> GetPagamentosByData(DateTime date)
        {
            var pagamentos = await _pagamentoRepository.GetPagamentosByData(date);
            return _mapper.Map<IEnumerable<PagamentoDTO>>(pagamentos);
        }

        public async Task<IEnumerable<PagamentoDTO>> GetPagamentosByMes(int mes)
        {
            var pagamentos = await _pagamentoRepository.GetPagamentosByMes(mes);
            return _mapper.Map<IEnumerable<PagamentoDTO>>(pagamentos);
        }


    }
}
