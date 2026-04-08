using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.CidadeDTO;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class CidadeService
    {
        private readonly ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public List<ListarCidadeDTO> Listar()
        {
            List<Cidade> cidades = _repository.Listar();

            List<ListarCidadeDTO> cidadesDto = cidades.Select(cidade => new ListarCidadeDTO
            {
                CidadeID = cidade.CidadeID,
                NomeCidade = cidade.NomeCidade,
                Estado = cidade.Estado

            }).ToList();

            return cidadesDto;
        }

        public ListarCidadeDTO BuscarCidadePorId(Guid cidadeID)
        {
            Cidade cidade = _repository.BuscarCidadePorId(cidadeID);

            if (cidade == null)
            {
                throw new DomainException("Cidade não encontrada");
            }

            ListarCidadeDTO cidadesDto = new ()
            {
                CidadeID = cidade.CidadeID
               
            };

            return cidadesDto;
        }

        public void Adicionar(CriarCidadeDto NovaCidadedto)
        {
            Validar.ValidarNome(NovaCidadedto.NomeCidade);

            Cidade CidadeExistente = _repository.BuscarCidadePorNome(NovaCidadedto.NomeCidade);

            if (CidadeExistente != null)
            {
                throw new DomainException("Já existe uma Cidade cadastrada com esse nome.");
            }

            Cidade cidade = new()
            {
                NomeCidade = NovaCidadedto.NomeCidade,
                Estado = NovaCidadedto.Estado

            };

            _repository.Adicionar(cidade);
        }

        public void Atualizar(Guid CidadeID, CriarCidadeDto NovaCidadedto)
        {
            Validar.ValidarNome(NovaCidadedto.NomeCidade);

            Cidade EntidadeCidade = _repository.BuscarCidadePorId(CidadeID);

            if (EntidadeCidade == null)
            {
                throw new DomainException("Cidade não encontrada.");
            }

            Cidade CidadeExistente = _repository.BuscarCidadePorNome(NovaCidadedto.NomeCidade);

            if (CidadeExistente != null)
            {
                throw new DomainException("Já existe uma Cidade cadastrada com esse nome.");
            }

            EntidadeCidade.NomeCidade = NovaCidadedto.NomeCidade;
            EntidadeCidade.Estado = NovaCidadedto.Estado;

            _repository.Atualizar(EntidadeCidade);
        }

    }
}


    

