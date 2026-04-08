namespace GerenciamentoPatrimonio.DTOS.LocalizaçãoDTO
{
    public class CriarLocalizaçãoDTO
    {
        public string NomeLocal { get; set; } = string.Empty;
        public int LocalSP { get; set; }
        public string? DescricaoSAP { get; set; }
        public Guid AreaID { get; set; }
    }
}
