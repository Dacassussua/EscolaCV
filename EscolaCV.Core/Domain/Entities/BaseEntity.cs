namespace EscolaCV.Core.Domain.Entities
{
    public class BaseEntity
    {
        public string CreateUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdateUserId { get; set; }=string.Empty;
        public DateTime? UpdateDate { get; set; }
    }
}
