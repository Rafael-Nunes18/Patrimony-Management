using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorID(Guid TipoUsuarioID);

        public void Adicionar(TipoUsuario tipoUsuario);

        public void Atualizar(TipoUsuario tipoUsuario);
    }
}
