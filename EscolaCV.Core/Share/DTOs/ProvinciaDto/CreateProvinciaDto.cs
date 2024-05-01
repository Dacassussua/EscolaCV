namespace EscolaCV.Core.Share.DTOs.ProvinciaDto
{
    public class CreateProvinciaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public string PaisId { get; set; }="AO";
    }
}
