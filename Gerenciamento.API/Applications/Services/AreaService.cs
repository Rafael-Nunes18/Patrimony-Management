using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.AreaDTO;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class AreaService
    {
        private readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository)
        {
            _repository = repository;
        }

        public List<ListarAreaDTO> Listar()
        {
            List<Area> areas = _repository.Listar();

            List<ListarAreaDTO> areasDto = areas.Select(area => new ListarAreaDTO
            {
                AreaID = area.AreaID,
                NomeArea = area.NomeArea
            }).ToList();

            return areasDto;
        }

        public ListarAreaDTO BuscarAreaPorID(Guid areaId)
        {
            Area area = _repository.BuscarAreaPorID(areaId);

            if (area == null)
            {
                throw new DomainException("Área não encontrada");
            }

            ListarAreaDTO areaDto = new ListarAreaDTO
            {
                AreaID = area.AreaID,
                NomeArea = area.NomeArea
            };

            return areaDto;
        }

        public void Adicionar(CriarAreaDTO dto)
        {
            Validar.ValidarNome(dto.NomeArea);

            Area areaExistente = _repository.BuscarAreaPorNome(dto.NomeArea);

            if (areaExistente != null)
            {
                throw new DomainException("Já existe uma área cadastrada com esse nome.");
            }

            Area area = new Area
            {
                NomeArea = dto.NomeArea
            };

            _repository.Adicionar(area);
        }

        public void Atualizar(Guid areaId, CriarAreaDTO dto)
        {
            Validar.ValidarNome(dto.NomeArea);

            Area areaBanco = _repository.BuscarAreaPorID(areaId);

            if (areaBanco == null)
            {
                throw new DomainException("Área não encontrada.");
            }

            Area areaExistente = _repository.BuscarAreaPorNome(dto.NomeArea);

            if (areaExistente != null)
            {
                throw new DomainException("Já existe uma área cadastrada com esse nome.");
            }

            areaBanco.NomeArea = dto.NomeArea;

            _repository.Atualizar(areaBanco);
        }

    }
}