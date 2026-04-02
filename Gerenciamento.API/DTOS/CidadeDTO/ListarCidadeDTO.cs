namespace GerenciamentoPatrimonio.DTOS.CidadeDTO
{
    public class ListarCidadeDTO
    {
        public Guid CidadeID { get; set; }
        public string NomeCidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
