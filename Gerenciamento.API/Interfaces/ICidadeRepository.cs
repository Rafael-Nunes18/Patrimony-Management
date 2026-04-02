using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ICidadeRepository
    {
        List<Cidade> Listar();
        Cidade BuscarCidadePorId(Guid CidadeID);
        Cidade BuscarCidadePorNome(string NomeCidade);
        void Adicionar(Cidade cidade);
        void Atualizar(Cidade cidade);
    }
}
