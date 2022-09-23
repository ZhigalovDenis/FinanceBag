using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceBag.Repositories

{
    public class AllRepository:  IRepositoryAll<Deal>
    {
        private readonly ApplicationDbContext _db;
        public AllRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Deal>> GetAll()
        {
            return await _db.Deals.Include(p => p.Actives).ToListAsync();
        }
    }
}
