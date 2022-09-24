using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Repositories
{
    public class TypeOfActiveRepository : IRepository<TypeOfActive, int>
    {
        private readonly ApplicationDbContext _db;
        public TypeOfActiveRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(int id)
        {
            var TypeOfAtciveFromDb = await _db.TypeOfActives.FindAsync(id);
            if (TypeOfAtciveFromDb != null)
            {
                _db.Remove(TypeOfAtciveFromDb);
            }
        }

        public async Task<TypeOfActive> Edit(TypeOfActive entity)
        {
            _db.TypeOfActives.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<TypeOfActive>> GetAll()
        {
            return await _db.TypeOfActives.ToListAsync();
        }

        public async Task<TypeOfActive> GetById(int id)
        {
            return await _db.TypeOfActives.FindAsync(id);
        }

        public Task<IEnumerable<dynamic>> GetFiltered()
        {
            throw new NotImplementedException();
        }

        public async Task<TypeOfActive> Insert(TypeOfActive entity)
        {
            await _db.TypeOfActives.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
