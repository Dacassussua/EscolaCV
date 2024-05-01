using EscolaCV.Core.Domain.Entities;

namespace EscolaCV.Manager.Interfaces.IPais
{
    public interface IPaisRepository : IBaseRepository<Pais>
    {
        Task<Pais> CreateAsync(Pais model);
        Task<bool> UpdateAsync(Pais model);
    }
}
