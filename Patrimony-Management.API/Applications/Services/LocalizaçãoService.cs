using GerenciamentoPatrimonio.Applications.Regra;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOS.LocalizaçãoDTO;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Applications.Services
{
    public class LocalizacaoService
    {
        private readonly ILocalizacaoRepository _repository;

        public LocalizacaoService(ILocalizacaoRepository repository)
        {
            _repository = repository;
        }

        public List<ListarLocalizacaoDto> Listar()
        {
            List<Localizacao> localizacoes = _repository.Listar();

            List<ListarLocalizacaoDto> localizacoesDto = localizacoes.Select(localizacao => new ListarLocalizacaoDto
            {
                LocalizacaoID = localizacao.LocalizacaoID,
                NomeLocal = localizacao.NomeLocal,
                LocalSAP = localizacao.LocalSAP,
                DescricaoSAP = localizacao.DescricaoSAP,
                AreaID = localizacao.AreaID
            }).ToList();

            return localizacoesDto;
        }

        public ListarLocalizacaoDto BuscarPorId(Guid localizacaoId)
        {
            Localizacao localizacao = _repository.BuscarPorId(localizacaoId);

            if (localizacao == null)
            {
                throw new DomainException("Localização não encontrada");
            }

            ListarLocalizacaoDto localizacaoDto = new ListarLocalizacaoDto
            {
                LocalizacaoID = localizacao.LocalizacaoID,
                NomeLocal = localizacao.NomeLocal,
                LocalSAP = localizacao.LocalSAP,
                DescricaoSAP = localizacao.DescricaoSAP,
                AreaID = localizacao.AreaID
            };

            return localizacaoDto;
        }

        public void Adicionar(CriarLocalizaçãoDTO dto)
        {
            Validar.ValidarNome(dto.NomeLocal);

            if (!_repository.AreaExiste(dto.AreaID))
            {
                throw new DomainException("Área informada não existe.");
            }

            Localizacao localizacao = new Localizacao
            {
                NomeLocal = dto.NomeLocal,
                LocalSAP = dto.LocalSP,
                DescricaoSAP = dto.DescricaoSAP,
                AreaID = dto.AreaID
            };

            _repository.Adicionar(localizacao);
        }

        public void Atualizar(Guid localizacaoId, CriarLocalizaçãoDTO dto)
        {
            Validar.ValidarNome(dto.NomeLocal);

            Localizacao localizacaoBanco = _repository.BuscarPorId(localizacaoId);

            if (localizacaoBanco == null)
            {
                throw new DomainException("Localização não encontrada.");
            }

            if (!_repository.AreaExiste(dto.AreaID))
            {
                throw new DomainException("Área informada não existe.");
            }

            localizacaoBanco.NomeLocal = dto.NomeLocal;
            localizacaoBanco.LocalSAP = dto.LocalSP;
            localizacaoBanco.DescricaoSAP = dto.DescricaoSAP;
            localizacaoBanco.AreaID = dto.AreaID;

            _repository.Atualizar(localizacaoBanco);
        }


    }
}
