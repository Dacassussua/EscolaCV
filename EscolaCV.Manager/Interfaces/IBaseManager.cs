using EscolaCV.Core.Share.ValuesObjects;

namespace EscolaCV.Manager.Interfaces
{
    public interface IBaseManager<T>
    {
        Task<T> GetByIdAsync(object Id);
        Task<T> GetByDescriptionAsync(string Description);
        Task<T> GetAllAsync();
        Task<T> DeleteAsync(object Id);
    }
}
