using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FinanceBag.Repositories
{
    public class DealRepository : IBaseRepository<Deal, int>, ISelectRepository, IGroupRepository
    {
        private readonly ApplicationDbContext _db;
        public DealRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(int id)
        {
            var AtciveFromDb = await _db.Deals.FindAsync(id);
            if (AtciveFromDb != null)
            {
                _db.Remove(AtciveFromDb);
            }
        }

        public async Task<Deal> Edit(Deal entity)
        {
            _db.Deals.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<Deal>> GetAll()
        {
            return await _db.Deals.Include(p => p.Actives).ToListAsync();
        }

        public async Task<Deal> GetById(int id)
        {
            return await _db.Deals.FindAsync(id);
        }

        public async Task<Deal> Insert(Deal entity)
        {
            await _db.Deals.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<dynamic>> Selected()
        {
            return await _db.Deals.GroupBy(g => g.ISIN_id).Select(s => new
            {
                ISIN = s.Key,
                Type = s.Select(x => x.Actives.TypeOfActive_id).First(),
                Ticker = s.Select(x => x.Actives.Ticker).First(),
                Count = s.Sum(x => x.Count),
                Sum = s.Sum(x => x.Sum),
                Avg = s.Sum(x => x.Sum) / s.Sum(x => x.Count),
                TradingMode = s.Select(x => x.Actives.TradingMode).First()
            }).OrderBy(x => x.Ticker).ToListAsync();
        }


        public async Task<IEnumerable<dynamic>> GroupByMonth()
        {
            return await _db.Deals.GroupBy(x => new
            {
                x.DT.Month,
                x.DT.Year
            }).Select(x => new
            {
                Date_ = x.Key.Month.ToString() + '-'+ x.Key.Year.ToString(),
                Cost =  x.Sum(x=>x.Sum)
            }).OrderBy(x => x.Cost).ToListAsync();
        }
    }
}
