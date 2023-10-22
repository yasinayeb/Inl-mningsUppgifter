

using System.Diagnostics;

namespace InlämningsUppgiften.Services;

public class FileServices
{
    public static void SaveToFile(string path, string content)
    {  
        try
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(content);
        }

        catch (Exception ex) { Debug.WriteLine(ex.Message ); }
     }

    public static string ReadFromFile(string  path)        
    {
        try
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);        //för att läsa filen måste kontrollera ifall filen existerar eller inte.
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
   
    }   

   
}
