namespace EscolaCV.Manager.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(object Id);
        Task<T> GetByDescriptionAsync(string Description);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> DeleteAsync(object Id);
    }
}
