using EscolaCV.Core.Domain.Entities;

namespace EscolaCV.Manager.Interfaces.IProvincia
{
    public interface IProvinciaRepository : IBaseRepository<Provincia>
    {
        Task<Provincia> CreateAsync(Provincia model);
        Task<bool> UpdateAsync(Provincia model);
        Task<IEnumerable<Provincia>> CreateProvincesAsync(IEnumerable<Provincia> model);
    }
}
