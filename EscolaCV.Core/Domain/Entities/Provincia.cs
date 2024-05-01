namespace EscolaCV.Core.Domain.Entities
{
    public class Provincia : BaseEntity
    {
        public int ProvinciaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public string PaisId { get; set; } =string.Empty;
        public Pais? pais { get; set; }
        public IEnumerable<Escola>? escolas { get; set; }

    }
}
