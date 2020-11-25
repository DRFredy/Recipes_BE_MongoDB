using MongoDB.Driver;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Recipes.DAL.Repositories.Interfaces
{
  /// <summary>
  /// MeasureTypes Repository
  /// </summary>
  public interface IMeasureTypesRepository
  {
    Task<IEnumerable<MeasureType>> GetAllAsync(
        FilterDefinition<MeasureType> filter = null,
        Func<IQueryable<MeasureType>, IOrderedQueryable<MeasureType>> orderBy = null,
        string includeProperties = "");

    Task<MeasureType> GetByIDAsync(string id);

    Task InsertAsync(MeasureType entity);

    Task DeleteAsync(object id);

    Task DeleteAsync(MeasureType entityToDelete);
  }
}