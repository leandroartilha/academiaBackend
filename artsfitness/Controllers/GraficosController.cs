using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace artsfitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficosController : ControllerBase
    {
        private readonly IGraficoService _graficoService;

        public GraficosController(IGraficoService graficoService)
        {
            _graficoService = graficoService;
        }

        // GET: api/<GraficosController>
        [HttpGet]
        [ActionName("Pegar Faturament")]
        public ActionResult<double> GetFaturamento()
        {
            var faturamento = _graficoService.GetFaturamentoTotal();
            return Ok(faturamento);
        }

        // GET api/<GraficosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GraficosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GraficosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GraficosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
