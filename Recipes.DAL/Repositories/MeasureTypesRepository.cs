using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Recipes.DAL.Repositories.Interfaces;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DAL.Repositories
{
  public class MeasureTypesRepository : IMeasureTypesRepository
  {
    private readonly IMongoCollection<MeasureType> _measureTypes;
    private readonly IMongoDBContext _context;

    public MeasureTypesRepository(IMongoDBContext context)
    {
      _context = context;
      _measureTypes = _context.GetCollection<MeasureType>("measureTypes");
    }

    public async Task<IEnumerable<MeasureType>> GetAllAsync(
        FilterDefinition<MeasureType> filter = null,
        Func<IQueryable<MeasureType>, IOrderedQueryable<MeasureType>> orderBy = null,
        string includeProperties = "")
    {
      var mts = await _measureTypes.FindAsync(filter);

      if (orderBy != null)
      {
        return mts.ToEnumerable().OrderBy(i => i.Name);
      }

      return mts.ToEnumerable();      
    }

    public async Task<MeasureType> GetByIDAsync(string id)
    {
      return await _measureTypes.Find(mt => mt.Id == id).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(MeasureType entity)
    {
      await _measureTypes.InsertOneAsync(entity);
    }

    public async Task DeleteAsync(object id)
    {
      await Task.FromResult(true);
    }

    public async Task DeleteAsync(MeasureType entityToDelete)
    {
      await Task.FromResult(true);
    }

    public async Task UpdateAsync(MeasureType entityToUpdate)
    {
      await Task.FromResult(true);
    }
  }
}