﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Infrastructure.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> _dbSet;
        //protected readonly ILogger _logger;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            //_logger = logger;
            _dbSet = context.Set<T>();      //This sets the dbset for the entity using the class passed in the context
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync<T>();
        }
        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
