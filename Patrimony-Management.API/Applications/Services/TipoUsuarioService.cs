using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.TipoUsuarioDTO;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Repositorys;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class TipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioService(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<ListarTipoUsuarioDto> Listar()
        {
            List<TipoUsuario> tipoUsuarios = _repository.Listar();

            List<ListarTipoUsuarioDto> tipoUsuarioDto = tipoUsuarios.Select(TipoUsuario => new ListarTipoUsuarioDto
            {
                TipoUsuarioID = TipoUsuario.TipoUsuarioID,
                NomeTipo = TipoUsuario.NomeTipo

            }).ToList();

            return tipoUsuarioDto;
        }

        public ListarTipoUsuarioDto BuscarPorID(Guid TipoUsuarioID)
        {
            TipoUsuario tipoUsuario = _repository.BuscarPorID(TipoUsuarioID);

            if (tipoUsuario == null)
            {
                throw new DomainException("ID não Encontrado");
            }

            ListarTipoUsuarioDto tipoUsuarioDto = new ListarTipoUsuarioDto
            {
                TipoUsuarioID = tipoUsuario.TipoUsuarioID,
                NomeTipo = tipoUsuario.NomeTipo

            };

            return tipoUsuarioDto;
        }

        public void Adicionar(CriarTipoUsuarioDto dto)
        {
            Validar.ValidarNome(dto.NomeTipo);

           TipoUsuario tipoUsuario = new TipoUsuario
            {
                NomeTipo = dto.NomeTipo
            };

            _repository.Adicionar(tipoUsuario);
        }

        public void Atualizar(Guid TipoUsuarioID, CriarTipoUsuarioDto dto )
        {
            Validar.ValidarNome(dto.NomeTipo);

            TipoUsuario tipoUsuario = _repository.BuscarPorID(TipoUsuarioID);

            if(tipoUsuario == null)
            {
                throw new DomainException("ID não Encontrado");
            }

            tipoUsuario.NomeTipo = dto.NomeTipo;


            _repository.Atualizar(tipoUsuario);

        }




    }
}
