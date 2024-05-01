using EscolaCV.Core.Domain.Entities;
using EscolaCV.Infra.Context;
using EscolaCV.Manager.Interfaces.IPais;
using Microsoft.EntityFrameworkCore;

namespace EscolaCV.Infra.Repository
{
    public class PaisRepository : IPaisRepository
    {
        private readonly EscolaCVContext _context;

        public PaisRepository(EscolaCVContext context)
        {
            _context = context;
        }

        public async Task<Pais> CreateAsync(Pais model)
        {
            var exist = await GetByIdAsync(model.PaisId);
            if (exist != null)
                return exist;

            try
            {
                await _context.pais.AddAsync(model!);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                 throw new Exception($"Erro ao criar Pais\n {ex}");
            }
     

            return model;
        }
        public async Task<bool> UpdateAsync(Pais model)
        {
            var entity = await GetByIdAsync(model.PaisId);
            if (entity == null)
                return false;

            try
            {
                _context.Entry(entity).CurrentValues.SetValues(model);
                _context.Entry(entity).Property(x => x.PaisId).IsModified = false;
                _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                _context.Entry(entity).Property(x => x.CreateUserId).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }



            return true;
        }
        public async Task<bool> DeleteAsync(object Id)
        {
            var exist = await GetByIdAsync(Id);
            if (exist == null)
                return false;

            try
            {
                _context.pais.Remove(exist);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.pais.AsNoTracking().ToListAsync();
        }

        public async Task<Pais> GetByIdAsync(object Id)
        {
            var PaisId = Convert.ToString(Id);
            var entity = await _context.pais.FirstOrDefaultAsync(x => x.PaisId.Equals(PaisId));
            return entity!;
        }

        public async Task<Pais> GetByPaisNameAsync(string PaisName)
        {
            var entity = await _context.pais.FirstOrDefaultAsync(x => x.Nome.Equals(PaisName));
            return entity!;
        }

  

        public async Task<Pais> GetByDescriptionAsync(string Description)
        {
            var PaisNome = Convert.ToString(Description);
            var entity = await _context.pais.FirstOrDefaultAsync(x => (x.Nome ?? "").Trim().ToUpper().Equals((PaisNome ?? "").Trim().ToUpper()));

            return entity!;
        }
    }
}
