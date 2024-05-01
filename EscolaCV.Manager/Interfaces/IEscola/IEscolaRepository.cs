using EscolaCV.Core.Domain.Entities;

namespace EscolaCV.Manager.Interfaces.IEscola
{
    public interface IEscolaRepository : IBaseRepository<Escola>
    {
        Task<Escola> CreateAsync(Escola model);
        Task<bool> UpdateAsync(Escola model);
        Task<IEnumerable<Escola>> CreateEscolasAsync(IEnumerable<Escola> collection);
    }
}
