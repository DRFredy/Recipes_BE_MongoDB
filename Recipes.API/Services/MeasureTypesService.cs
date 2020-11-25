using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Recipes.API.Services.Interfaces;
using Recipes.DAL;
using Recipes.Models;
using Recipes.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Services
{
  public class MeasureTypesService : IMeasureTypesService
  {
    private readonly UnitOfWork _unitOkWork;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly string _webRootPath;

    public MeasureTypesService(IMongoDBContext context, IConfiguration config, IMapper mapper)
    {
      _mapper = mapper;
      _config = config;
      _unitOkWork = new UnitOfWork(context, _webRootPath, _config, _mapper);
      _webRootPath = Directory.GetCurrentDirectory();
    }

    public async Task<MeasureType> GetByIDAsync(string id)
    {
      if(string.IsNullOrWhiteSpace(id))
      {
        throw new ArgumentNullException(nameof(id));
      }

      var qttyType = await _unitOkWork.MeasureTypesRepository.GetByIDAsync(id);
      
      return qttyType;
    }

    public async Task<IList<MeasureType>> GetListAsync(string filterBy, string filterContent, string orderBy)
    {
      string includeProperties = null;

      FilterDefinition<MeasureType> filterFunc = filterBy switch
      {
        "Id" => Builders<MeasureType>.Filter.Eq("_id", filterContent),
        "Name" => Builders<MeasureType>.Filter.Text("name", filterContent),
        _ => Builders<MeasureType>.Filter.Empty
      };

      Func<IQueryable<MeasureType>, IOrderedQueryable<MeasureType>> orderByFunc = orderBy switch
      {
        "Id" => q => q.OrderBy(s => s.Id),
        "Name" => q => q.OrderBy(s => s.Name),
        _ => q => q.OrderBy(s => s.Name)
      };

      var MeasureTypes = await _unitOkWork.MeasureTypesRepository.GetAllAsync(filterFunc, orderByFunc, includeProperties);

      return MeasureTypes.ToList();
    }

    public async Task<MeasureTypeDTO> InsertAsync(CreateMeasureTypeDTO createDTO)
    {
      try
      {
        var entity = _mapper.Map<MeasureType>(createDTO);
        await _unitOkWork.MeasureTypesRepository.InsertAsync(entity);
        var entityDTO = _mapper.Map<MeasureTypeDTO>(entity);
        
        return entityDTO;
      }
      catch //(Exception ex) 
      {
        return null;
      }
    }

    public async Task<bool> DeleteAsync(object id)
    {
      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(MeasureTypeDTO entityToDelete)
    {
      return await Task.FromResult(true);
    }
  }
}