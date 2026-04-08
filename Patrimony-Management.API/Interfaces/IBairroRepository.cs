using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface IBairroRepository
    {
        List<Bairro> Listar();
        Bairro BuscarPorId(Guid bairroId);
        void Adicionar(Bairro bairro);
        void Atualizar(Bairro bairro);
        bool CidadeExiste(Guid cidadeId);
    }
}