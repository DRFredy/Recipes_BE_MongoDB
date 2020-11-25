using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
  /// <summary>
  /// MeasureType entity
  /// </summary>
  public class MeasureType
  {
    /// <summary>
    /// MeasureType Id
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// MeasureType Name
    /// </summary>
    [BsonElement("name")]
    [Required] public string Name { get; set; }
  }
}
