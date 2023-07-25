namespace RESTAPI.Services;

public static class FileService
{
    public  static string? Reader(string path)
    {
        using StreamReader streamReader = new("Products.json");
        var json = streamReader.ReadToEnd();      
        streamReader.Close();
        return json;
    }
    
}