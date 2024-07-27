using MagicVilla_WebApi.Data;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicVilla_WebApi.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext context;

        public VillaNumberRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber villa)
        {
             context.VillaNumbers.Update(villa);
            await context.SaveChangesAsync();
            return villa;
        }
    }
}
