using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace artsfitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        [ActionName("ListarAlunos")]
        public async Task<ActionResult<Task<AlunoDTO>>> ListarAlunos()
        {
            var alunos = await _alunoService.GetAllAlunos();
            if(alunos == null)
            {
                return NotFound();
            }
            return Ok(alunos);
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDTO>> ExibirAluno(int id)
        {
            var aluno = await _alunoService.GetAluno(id);
            if(aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        // POST api/<AlunosController>
        [HttpPost]
        public async Task<ActionResult<AlunoDTO>> CriarAluno([FromBody] AlunoDTO aluno)
        {
            var alunoCriado = await _alunoService.CreateAluno(aluno);
            if(alunoCriado == null)
            {
                return BadRequest();
            }
            return Ok(alunoCriado);
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoDTO>> AtualizarAluno(int id, [FromBody] AlunoDTO aluno)
        {
            if (id != aluno.Id)
                return BadRequest();

            await _alunoService.UpdateAluno(aluno);
            return Ok(aluno);
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoDTO>> DeletarAluno(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var alunoDeletado = await _alunoService.DeleteAluno(id);
            return Ok(alunoDeletado);
        }
    }
}
