using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositorys
{
    public class CidadeRepository: ICidadeRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public CidadeRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }
        public List<Cidade> Listar()
        {
            return _context.Cidade.OrderBy(cidade => cidade.NomeCidade).ToList();
        }

        public Cidade BuscarCidadePorId(Guid CidadeID)
        {
            return _context.Cidade.Find(CidadeID)!;
        }

        public Cidade BuscarCidadePorNome(string NomeCidade)
        {
            return _context.Cidade.FirstOrDefault(Cargo => Cargo.NomeCidade == NomeCidade)!;
        }
 

        public void Adicionar(Cidade Cidade)
        {
            _context.Cidade.Add(Cidade);
            _context.SaveChanges();
        }

        public void Atualizar(Cidade cidade)
        {
            if (cidade == null)
            {
                return;
            }

            Cidade EntidadeCidade = _context.Cidade.Find(cidade.CidadeID)!;

            if (EntidadeCidade == null)
            {
                return;
            }

            EntidadeCidade.NomeCidade = cidade.NomeCidade;
            _context.SaveChanges();
        }
    }





}




