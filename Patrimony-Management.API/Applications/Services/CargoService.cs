using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.CargoDTo;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Repositorys;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class CargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository)
        {
            _repository = repository;
        }

        public List<ListarCargosDTO> Listar()
        {
            List<Cargo> cargo = _repository.Listar();

            List<ListarCargosDTO> cargosDTOs = cargo.Select(cargo => new ListarCargosDTO
            {
                CargoID = cargo.CargoID,
                NomeCargo =  cargo.NomeCargo

            }).ToList();

            return cargosDTOs;
        }
        public ListarCargosDTO BuscarPorID(Guid cargoID)
        {
            Cargo cargo = _repository.BuscarPorID(cargoID);

            if (cargo == null)
            {
                throw new DomainException("Cargo não encontrado");
            }

            ListarCargosDTO cargoDto = new ListarCargosDTO
            {
                CargoID = cargo.CargoID,
                NomeCargo = cargo.NomeCargo
            };

            return cargoDto;
        }

        public ListarCargosDTO BuscarPorNome(string NomeCargo)
        {
            Cargo cargonome = _repository.BuscarPorNome(NomeCargo);

            ListarCargosDTO nomecargodto = new ListarCargosDTO
            {
                NomeCargo = cargonome.NomeCargo
            };

            return nomecargodto;
        }



        public void Adicionar(CriarCargoDTO cargodto)
        {
            Validar.ValidarNome(cargodto.NomeCargo);

            Cargo cargoExistente = _repository.BuscarPorNome(cargodto.NomeCargo);

            if (cargoExistente != null)
            {
                throw new DomainException("Já existe uma cargo cadastrado com esse nome.");
            }

            Cargo cargo = new Cargo
            {
                NomeCargo = cargodto.NomeCargo
            };

            _repository.Adicionar(cargo);
        }

        public void Atualizar(Guid cargoID, CriarCargoDTO cargodto)
        {
            Validar.ValidarNome(cargodto.NomeCargo);

            Cargo CargoBanco = _repository.BuscarPorID(cargoID);

            if (CargoBanco == null)
            {
                throw new DomainException("Cargo não encontrado.");
            }

            Cargo cargoExistente = _repository.BuscarPorNome(cargodto.NomeCargo);

            if (cargoExistente != null)
            {
                throw new DomainException("Já existe um Cargo cadastrado com esse nome.");
            }

            CargoBanco.NomeCargo = cargodto.NomeCargo;

            _repository.Atualizar(CargoBanco);
        }

    }
}

