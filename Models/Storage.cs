using System.Text.Encodings.Web;
using System.Text.Json;

namespace Westcoast_EShop.Models;

public class Storage
{

  private static JsonSerializerOptions _options = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
  };

  // 1. Skapa en static metod för att spara ner objekt till json...
  public static void WriteJson(string path, List<SalesOrder> orders)
  {
    var json = JsonSerializer.Serialize(orders, _options);
    File.WriteAllText(path, json);
  }
}