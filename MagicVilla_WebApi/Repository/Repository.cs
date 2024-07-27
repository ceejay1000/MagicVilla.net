using MagicVilla_WebApi.Data;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query =dbSet.AsQueryable();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            this.dbSet.Remove(entity);
            await this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
