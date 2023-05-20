namespace backend.Models;

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