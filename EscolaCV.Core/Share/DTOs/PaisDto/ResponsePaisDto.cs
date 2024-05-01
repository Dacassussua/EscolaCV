namespace EscolaCV.Core.Share.DTOs.PaisDto
{
    public class ResponsePaisDto : UpdatePaisDto
    {
        public string CreateUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
