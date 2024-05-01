namespace EscolaCV.Core.Share.DTOs.EscolaDto
{
    public class ResponseEscolaDto : UpdateEscolaDto
    {
        public string CreateUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
