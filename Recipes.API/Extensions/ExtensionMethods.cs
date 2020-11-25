using Microsoft.Extensions.Configuration;

namespace Recipes.Models.Extensions
{
#pragma warning disable 1591
  public static class ExtensionMethods
  {
    public static string GetAppTitle(this IConfiguration config) =>
      config.GetSection("AppInfo")["Title"];

    public static string GetAppVersion(this IConfiguration config) =>
      config.GetSection("AppInfo")["Version"];

    public static string GetAppDescription(this IConfiguration config) =>
      config.GetSection("AppInfo")["Description"];

    public static string GetSwaggerJsonFilePaths(this IConfiguration config, string version) =>
      config.GetSection("SwaggerJsonFilePaths")[version];
  }
}