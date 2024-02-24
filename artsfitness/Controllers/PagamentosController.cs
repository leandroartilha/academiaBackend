using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace artsfitness.Controllers
{
    //[Authorize(Roles = "Gentleman")]
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentosController(IPagamentoService pagamento)
        {
            _pagamentoService = pagamento;
        }

        // POST api/<PagamentosController>
        [HttpPost]
        public async Task<ActionResult<PagamentoDTO>> Post([FromBody] PagamentoDTO pagamento)
        {
            try
            {
                var pagamentoEfetuado = await _pagamentoService.CreatePagamento(pagamento);
                if (pagamentoEfetuado == null)
                {
                    return NotFound();
                }
                return Ok(pagamentoEfetuado);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        // GET: api/<PagamentosController>
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoDTO>>> ListarPagamentos()
        {
            var pagamentos = await _pagamentoService.GetAllPagamentos();

            if(pagamentos == null)
            {
                return NotFound();
            }
            return Ok(pagamentos);
        }

        // GET api/<PagamentosController>/5
        [HttpGet("{idAluno}")]
        public async Task<ActionResult<IEnumerable<PagamentoDTO>>> ListarPagamentoPorAluno(int idAluno)
        {
            var pagamentos = await _pagamentoService.GetPagamentosByAluno(idAluno);
            if (pagamentos == null)
            {
                return NotFound();
            }
            return Ok(pagamentos);
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<PagamentoDTO>>> ListarPagamentoPorData(DateTime date)
        {
            var pagamentos = await _pagamentoService.GetPagamentosByData(date);
            if (pagamentos == null)
            {
                return NotFound();
            }
            return Ok(pagamentos);
        }

        [HttpGet("ByMes/{mes}")]
        public async Task<ActionResult<IEnumerable<PagamentoDTO>>> ListarPagamentoPorMes(int mes)
        {
            var pagamentos = await _pagamentoService.GetPagamentosByMes(mes);
            if (pagamentos == null)
            {
                return NotFound();
            }
            return Ok(pagamentos);
        }
    }
}
