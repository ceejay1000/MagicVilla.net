﻿using MagicVilla_WebApi.Models;
using System.Linq.Expressions;

namespace MagicVilla_WebApi.Repository.IRepository
{
    public interface IVillaNumberRepository: IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber villa);
    }
}
