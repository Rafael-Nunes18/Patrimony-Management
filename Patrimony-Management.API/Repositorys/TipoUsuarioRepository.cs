using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositorys
{
    public class TipoUsuarioRepository: ITipoUsuarioRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public TipoUsuarioRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuario.OrderBy(TipoUsuario => TipoUsuario.NomeTipo).ToList();
        }

       public TipoUsuario BuscarPorID(Guid TipoUsuarioID)
        {
            return _context.TipoUsuario.Find(TipoUsuarioID)!;
        }

        public void Adicionar(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuario.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public void Atualizar(TipoUsuario tipoUsuario)
        {
            if(tipoUsuario == null)
            {
                return;
            }

            TipoUsuario EntidadeTipoUsuario = _context.TipoUsuario.Find(tipoUsuario.TipoUsuarioID)!;

            if(EntidadeTipoUsuario == null)
            {
                return;
            }

            EntidadeTipoUsuario.NomeTipo = tipoUsuario.NomeTipo;

            _context.SaveChanges();
        }
    }
}
