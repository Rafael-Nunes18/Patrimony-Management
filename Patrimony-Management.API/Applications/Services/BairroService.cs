using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;
using GestaoPatrimonios.DTOs.Bairro;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class BairroService
    {
        private readonly IBairroRepository _repository;

        public BairroService(IBairroRepository repository)
        {
            _repository = repository;
        }

        public List<ListarBairroDto> Listar()
        {
            List<Bairro> bairros = _repository.Listar();

            List<ListarBairroDto> bairrosDto = bairros.Select(bairro => new ListarBairroDto
            {
                BairroID = bairro.BairroID,
                NomeBairro = bairro.NomeBairro,
                CidadeID = bairro.CidadeID
            }).ToList();

            return bairrosDto;
        }

        public ListarBairroDto BuscarPorId(Guid bairroId)
        {
            Bairro bairro = _repository.BuscarPorId(bairroId);

            if (bairro == null)
            {
                throw new DomainException("Bairro não encontrado.");
            }

            return new ListarBairroDto
            {
                BairroID = bairro.BairroID,
                NomeBairro = bairro.NomeBairro,
                CidadeID = bairro.CidadeID
            };
        }

        public void Adicionar(CriarBairroDto dto)
        {
            Validar.ValidarNome(dto.NomeBairro);


            if (!_repository.CidadeExiste(dto.CidadeID))
            {
                throw new DomainException("Cidade informada não existe.");
            }

            Bairro bairro = new Bairro
            {
                NomeBairro = dto.NomeBairro,
                CidadeID = dto.CidadeID
            };

            _repository.Adicionar(bairro);
        }

        public void Atualizar(Guid bairroId, CriarBairroDto dto)
        {
            Validar.ValidarNome(dto.NomeBairro);

            Bairro bairroBanco = _repository.BuscarPorId(bairroId);

            if (bairroBanco == null)
            {
                throw new DomainException("Bairro não encontrado.");
            }

           

            if (!_repository.CidadeExiste(dto.CidadeID))
            {
                throw new DomainException("Cidade informada não existe.");
            }

            bairroBanco.NomeBairro = dto.NomeBairro;
            bairroBanco.CidadeID = dto.CidadeID;

            _repository.Atualizar(bairroBanco);
        }
    }
}