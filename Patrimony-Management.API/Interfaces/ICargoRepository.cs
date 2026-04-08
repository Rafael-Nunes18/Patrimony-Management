using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ICargoRepository
    {

        List<Cargo> Listar();

        Cargo BuscarPorID(Guid CargoID);
        Cargo BuscarPorNome(string NomeCargo);
        public void Adicionar(Cargo cargo);
        public void Atualizar(Cargo cargo);
    }
}
