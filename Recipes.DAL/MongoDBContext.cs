using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recipes.DAL;
using Recipes.DAL.Configuration;

public class MongoDBContext : IMongoDBContext
{
  private IMongoDatabase _db { get; set; }
  private IMongoClient _mongoClient { get; set; }
  public IClientSessionHandle Session { get; set; }
  public MongoDBContext(IOptions<ConnectionStrings> connectionStringsOption)
  {
    _mongoClient = new MongoClient(connectionStringsOption.Value.DefaultConnection);
    _db = _mongoClient.GetDatabase("recipes");
  }

  public IMongoCollection<T> GetCollection<T>(string name)
  {
    if (string.IsNullOrEmpty(name))
    {
      return null;
    }
    return _db.GetCollection<T>(name);
  }
}