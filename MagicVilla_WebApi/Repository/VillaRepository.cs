using MagicVilla_WebApi.Data;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicVilla_WebApi.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext context;

        public VillaRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public async Task<Villa> UpdateAsync(Villa villa)
        {
             context.Villas.Update(villa);
            await context.SaveChangesAsync();
            return villa;
        }
    }
}
