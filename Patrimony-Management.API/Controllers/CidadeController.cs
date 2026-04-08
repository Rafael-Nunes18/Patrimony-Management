using GerenciamentoPatrimonio.Applications.Services;
using GerenciamentoPatrimonio.DTOS.CidadeDTO;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly CidadeService _service;

        public CidadeController(CidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarCidadeDTO>> Listar()
        {
            List<ListarCidadeDTO> cidades = _service.Listar();

            return Ok(cidades);
        }

        [HttpGet("{id}")]
        public ActionResult<ListarCidadeDTO> BuscarCidadePorID(Guid id)
        {
            try
            {
                ListarCidadeDTO cidades = _service.BuscarCidadePorId(id);

                return Ok(cidades);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarCidadeDto cidadedto)
        {
            try
            {
                _service.Adicionar(cidadedto);
                return Created();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, CriarCidadeDto cidadedto)
        {
            try
            {
                _service.Atualizar(id, cidadedto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
