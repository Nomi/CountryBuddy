namespace backend.Models;

/// <summary>
/// "Model" class for representation of a Continent (excluding its countries).
/// </summary>
public class Continent
{
    public String Code {get;set;}
    public String Name {get;set;}
    public Continent(String continentCode, String continentName)
    {
        Code=continentCode;
        Name=continentName;
    }
    public override string ToString()
    {
        return $"Code: {Code},\n" +
         $"Name: {Name}\n";
    }
}