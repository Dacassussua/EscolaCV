using EscolaCV.Core.Domain.Entities;
using EscolaCV.Infra.Context;
using EscolaCV.Manager.Interfaces.IProvincia;
using Microsoft.EntityFrameworkCore;

namespace EscolaCV.Infra.Repository
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly EscolaCVContext _context;

        public ProvinciaRepository(EscolaCVContext context)
        {
            _context = context;
        }

        public async Task<Provincia> CreateAsync(Provincia model)
        {
            var exist = await GetByIdAsync(model.ProvinciaId);
            if (exist != null)
                return exist;

            try
            {

                await _context.provincia.AddAsync(model!);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar Pais\n {ex}");
            }

            return model;
        }
        public async Task<IEnumerable<Provincia>> CreateProvincesAsync(IEnumerable<Provincia> provinces)
        {
            var newprovinces = new List<Provincia>();
            var oldprovinces = new List<Provincia>();
            foreach (var provincia in provinces)
            {
                var notexist = await GetByDescriptionAsync(provincia.Nome);
                if (notexist == null)
                    newprovinces.Add(provincia!);
                else
                    oldprovinces.Add(notexist!);
            }

            try
            {

                await _context.provincia.AddRangeAsync(newprovinces!);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir as províncias\n{ex}");
            }

            if (newprovinces.Count <= 0)
                return oldprovinces;


            return newprovinces;
        }

        public async Task<bool> UpdateAsync(Provincia model)
        {
            var entity = await GetByIdAsync(model.ProvinciaId);
            if (entity == null)
            {
                return false;
            }

            try
            {
                _context.Entry(entity).CurrentValues.SetValues(model);
                _context.Entry(entity).Property(x => x.ProvinciaId).IsModified = false;
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
            if (exist != null)
            {
                _context.provincia.Remove(exist);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Provincia>> GetAllAsync()
        {
            return await _context.provincia.AsNoTracking().ToListAsync();
        }

        public async Task<Provincia> GetByIdAsync(object Id)
        {
            var ProvinciaId = Convert.ToInt32(Id);
            var entity = await _context.provincia.FirstOrDefaultAsync(x => x.ProvinciaId == ProvinciaId);
            return entity!;
        }

        public async Task<Provincia> GetByDescriptionAsync(string Description)
        {
            var ProvinciaNome = Convert.ToString(Description);
            var entity = await _context.provincia.FirstOrDefaultAsync(x => (x.Nome??"").Trim().ToUpper().Equals((ProvinciaNome??"").Trim().ToUpper()));
         
            return entity!;
        }
    }
}
