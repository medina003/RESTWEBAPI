using System.Text.Json;

namespace RESTAPI.Services;

public class SerializeService
{
    public static void Serialize(string path,List<Product> products,bool append)
    {
        using StreamWriter streamWriter = new("Products.json",false);
        streamWriter.Write(JsonSerializer.Serialize(products));
        streamWriter.Close();
    }
}