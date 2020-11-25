using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using Recipes.DAL.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Recipes.DAL.Extensions
{
  public static class ServiceCollectionExtensions
  {
    #region appsettings.json related extensions
    public static string GetDataProviderName(this IConfiguration config) =>
      config.GetSection("Data")["Provider"];

    public static string GetImagesPath(this IConfiguration config) =>
      config.GetSection("ImagesPath").Value;
    #endregion
    private static IEnumerable<T> GetImplementationsOf<T>(this Assembly assembly)
    {
      var result = new List<T>();

      var types = assembly.GetTypes()
          .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && typeof(T).IsAssignableFrom(t))
          .ToList();

      foreach (var type in types)
      {
        var instance = (T)Activator.CreateInstance(type);
        result.Add(instance);
      }

      return result;
    }
  }
}