using EscolaCV.Core.Domain.Entities;
using EscolaCV.Infra.Context;
using EscolaCV.Manager.Interfaces.IEscola;
using Microsoft.EntityFrameworkCore;

namespace EscolaCV.Infra.Repository
{
    public class EscolaRepository: IEscolaRepository
    {
        private readonly EscolaCVContext _context;

        public EscolaRepository(EscolaCVContext context)
        {
            _context = context;
        }

        public async Task<Escola> CreateAsync(Escola model)
        {
            var exist = await GetByIdAsync(model.EscolaId);
            if (exist != null)
                return exist;

            try
            {
                await _context.escola.AddAsync(model!);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar escola\n {ex}");
            }


            return model;
        }
        public async Task<bool> UpdateAsync(Escola model)
        {
            var entity = await GetByIdAsync(model.EscolaId);
            if (entity == null)
                return false;
            try
            {

                _context.Entry(entity).CurrentValues.SetValues(model);
                _context.Entry(entity).Property(x => x.EscolaId).IsModified = false;
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
                _context.escola.Remove(exist);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Escola>> GetAllAsync()
        {
            return await _context.escola.AsNoTracking().ToListAsync();
        }

        public async Task<Escola> GetByIdAsync(object Id)
        {
            var EscolaId = Convert.ToInt32(Id);
            var entity = await _context.escola.FirstOrDefaultAsync(x => x.EscolaId.Equals(EscolaId));
            return entity!;
        }

        public async Task<Escola> GetByDescriptionAsync(string Description)
        {
            var EscolaNome = Convert.ToString(Description);
            var entity = await _context.escola.FirstOrDefaultAsync(x => (x.Nome ?? "").Trim().ToUpper().Equals((EscolaNome ?? "").Trim().ToUpper()));

            return entity!;
        }

        public async Task<IEnumerable<Escola>> CreateEscolasAsync(IEnumerable<Escola> collection)
        {
            var newEscolas = new List<Escola>();
            foreach (var escola in collection)
            {
                var notexist = await GetByDescriptionAsync(escola.Nome);
                if (notexist == null)
                    newEscolas.Add(escola!);
            }

            try
            {

                await _context.escola.AddRangeAsync(newEscolas!);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir as províncias\n{ex}");
            }

            return newEscolas;
        }
    }
}
