namespace EscolaCV.Core.Domain.Entities
{
    public class Pais : BaseEntity
    {
        public string PaisId { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public IEnumerable<Provincia>? provincias { get; set; }
    }
}
