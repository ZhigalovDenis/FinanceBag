using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceBag.Repositories

{
    public class ActiveRepository : IBaseRepository<Active, string>, IViewBag
    {
        private readonly ApplicationDbContext _db;
        public ActiveRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(string id)
        {
            var AtciveFromDb = await _db.Actives.FindAsync(id);
            if (AtciveFromDb != null)
            {
                _db.Remove(AtciveFromDb);
            }
        }

        public async Task<Active> Edit(Active entity)
        {
            _db.Actives.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<Active>> GetAll()
        {
            return await _db.Actives.Include(p => p.TypeOfActive).OrderBy(o => o.Ticker).ToListAsync();

        }

        public async Task<Active> GetById(string id)
        {
            return await _db.Actives.FindAsync(id);
        }

        public async Task<IEnumerable<dynamic>> GetListToViewBag()
        {
            return await _db.Actives.Select(x => x.ISIN_id).ToListAsync();
        }

        public async Task<Active> Insert(Active entity)
        {
            await _db.Actives.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
