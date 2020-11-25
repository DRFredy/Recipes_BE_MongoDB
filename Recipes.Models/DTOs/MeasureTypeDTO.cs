using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Recipes.Models;

namespace Recipes.Models.DTOs
{
  /// <summary>
  /// MeasureType DTO
  /// </summary>
  public class CreateMeasureTypeDTO
  {
    /// <summary>
    /// MeasureType Name
    /// </summary>
    [Required] public string Name { get; set; }
  }

  public class MeasureTypeDTO
  {
    /// <summary>
    /// MeasureType Id
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// MeasureType Name
    /// </summary>
    public string Name { get; set; }
  }

  public class CreateMeasureTypeDTO_To_MeasureType__Converter : ITypeConverter<CreateMeasureTypeDTO, MeasureType>
  {
    public MeasureType Convert(CreateMeasureTypeDTO source, MeasureType destination, ResolutionContext context)
    {
      return new MeasureType
      {
        Name = source.Name
      };
    }
  }

  public class MeasureTypeDTO_To_MeasureType__Converter : ITypeConverter<MeasureTypeDTO, MeasureType>
  {
    public MeasureType Convert(MeasureTypeDTO source, MeasureType destination, ResolutionContext context)
    {
      return new MeasureType
      {
        Id = source.Id,
        Name = source.Name
      };
    }
  }

  public class MeasureType_To_MeasureTypeDTO__Converter : ITypeConverter<MeasureType, MeasureTypeDTO>
  {
    public MeasureTypeDTO Convert(MeasureType source, MeasureTypeDTO destination, ResolutionContext context)
    {
      return new MeasureTypeDTO
      {
        Id = source.Id,
        Name = source.Name
      };
    }
  }
}