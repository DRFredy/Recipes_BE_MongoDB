using MongoDB.Driver;

namespace Recipes.DAL
{
  public interface IMongoDBContext
  {
      IMongoCollection<T> GetCollection<T>(string name);
  }
}