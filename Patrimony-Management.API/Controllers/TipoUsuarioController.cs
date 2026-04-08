using GerenciamentoPatrimonio.Applications.Services;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.TipoUsuarioDTO;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioService _service;

        public TipoUsuarioController(TipoUsuarioService service)
        {
            _service = service;
        }


        [HttpGet]

        public ActionResult<List<ListarTipoUsuarioDto>> Listar()
        {
            List<ListarTipoUsuarioDto> tipos = _service.Listar();
            return Ok(tipos);
        }

        [HttpGet("{id}")]

        public ActionResult<ListarTipoUsuarioDto> BuscarPorID(Guid id)
        {
            try
            {
                ListarTipoUsuarioDto tipoUsuariodto = _service.BuscarPorID(id);
                return Ok(tipoUsuariodto);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]

        public ActionResult Adicionar(CriarTipoUsuarioDto dto)
        {
            try
            {
                _service.Adicionar(dto);
                return Created();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult Atualizar(Guid id, CriarTipoUsuarioDto dto)
        {
            try
            {
                _service.Atualizar(id,dto);
                return Created();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    }
}
