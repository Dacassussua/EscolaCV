using EscolaCV.Core.Domain.ValueObjects;

namespace EscolaCV.Core.Domain.Entities
{
    public class Escola : BaseEntity
    {
        public int EscolaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public Email Email { get; set; } = null!;
        public int NumSalas { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia? provincia { get; set; }
    }
}
