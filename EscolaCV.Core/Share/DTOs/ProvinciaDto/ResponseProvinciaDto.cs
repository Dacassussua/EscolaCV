namespace EscolaCV.Core.Share.DTOs.ProvinciaDto
{
    public class ResponseProvinciaDto : UpdateProvinciaDto
    {
        public string CreateUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
