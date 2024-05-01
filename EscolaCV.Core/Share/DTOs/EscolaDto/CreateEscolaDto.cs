namespace EscolaCV.Core.Share.DTOs.EscolaDto
{
    public class CreateEscolaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int NumSalas { get; set; }
        public string Provincia { get; set; } = string.Empty;
    }
}
