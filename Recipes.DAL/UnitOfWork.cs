using AutoMapper;
using Microsoft.Extensions.Configuration;
using Recipes.DAL.Repositories;
using Recipes.DAL.Repositories.Interfaces;

namespace Recipes.DAL
{
  public class UnitOfWork
  {
    private readonly IMongoDBContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly string _webRootPath;

    private IMeasureTypesRepository _measureTypesRepository;

    public UnitOfWork(IMongoDBContext context, string webRootPath, IConfiguration config, IMapper mapper)
    {
      _webRootPath = webRootPath;
      _config = config;
      _mapper = mapper;
      _context = context;
    }

    public IMeasureTypesRepository MeasureTypesRepository
    {
      get
      {
        if (_measureTypesRepository == null)
        {
          _measureTypesRepository = new MeasureTypesRepository(_context);
        }

        return _measureTypesRepository;
      }
    }
  }
}