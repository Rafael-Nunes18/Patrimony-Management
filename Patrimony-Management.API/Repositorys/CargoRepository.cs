using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositorys
{
    public class CargoRepository : ICargoRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public CargoRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Cargo> Listar()
        {
            return _context.Cargo.OrderBy(cargo => cargo.NomeCargo).ToList();
        }

        public Cargo BuscarPorID(Guid CargoID)
        {
             return _context.Cargo.Find(CargoID)!;
        }

        public Cargo BuscarPorNome(string NomeCargo)
        {
            return _context.Cargo.FirstOrDefault(cargo => cargo.NomeCargo == NomeCargo)!;
        }

        public void Adicionar(Cargo cargo)
        {
            _context.Cargo.Add(cargo);
            _context.SaveChanges();

        }

        public void Atualizar(Cargo cargo)
        {
            _context.Cargo.Update(cargo);
            _context.SaveChanges();
        }
    }
}
