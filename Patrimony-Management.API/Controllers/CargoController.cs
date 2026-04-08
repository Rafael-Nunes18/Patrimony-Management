using GerenciamentoPatrimonio.Applications.Services;
using GerenciamentoPatrimonio.DTOS.CargoDTo;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _service;

        public CargoController(CargoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarCargosDTO>> Listar()
        {
            List<ListarCargosDTO> cargos = _service.Listar();

            return Ok(cargos);
        }

        [HttpGet("{id}")]
        public ActionResult<ListarCargosDTO> BuscarPorID(Guid id)
        {
            try
            {
                ListarCargosDTO cargo = _service.BuscarPorID(id);

                return Ok(cargo);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Adicionar(CriarCargoDTO cargodto)
        {
            try
            {
                _service.Adicionar(cargodto);
                return Created();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id , CriarCargoDTO cargodto)
        {
            try
            {
                _service.Atualizar(id, cargodto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

