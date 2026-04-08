using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface IAreaRepository
    {
        List<Area> Listar();
        Area BuscarAreaPorID(Guid areaId);
        Area BuscarAreaPorNome(string nomeArea);
        void Adicionar(Area area);
        void Atualizar(Area area);
    }
}