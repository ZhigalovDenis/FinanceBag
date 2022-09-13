﻿using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Repositories
{
    public class DealRepository : IRepository<Deal, int>
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
            //return await _db.Actives.ToListAsync();
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
    }
}
