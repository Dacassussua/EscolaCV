
using EscolaCV.Manager.ValuesObjects;

namespace EscolaCV.Manager.Interfaces
{
    public interface IRequestBase<C, U>
    {
        Task<Response> CreateAsync(C model);
        Task<Response> UpdateAsync(U model);
    }
}
