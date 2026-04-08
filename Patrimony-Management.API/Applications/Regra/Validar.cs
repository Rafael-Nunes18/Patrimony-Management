using GerenciamentoPatrimonio.Exceptions;

namespace GerenciamentoPatrimonio.Applications.Regra
{
    public class Validar
    {
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório");
            }
        }
    }
}