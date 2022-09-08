﻿using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Repositories

{
    public class ActiveRepository : IRepository<Active, string>
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
            return await _db.Actives.ToListAsync();
        }

        public async Task<Active> GetById(string id)
        {
            return await _db.Actives.FindAsync(id);
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