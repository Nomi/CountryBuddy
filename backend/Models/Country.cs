namespace backend.Models;

/// <summary>
/// "Model" class for representation of a Country.
/// </summary>
public class Country
{
    public String Code {get;set;}
    public String Name {get;set;}
    public string Currency {get;set;}
    public string Phone {get;set;}
    public List<Language> Languages {get;set;}
    public Continent Continent {get;set;} //Redundant for the given case, but might be useful in other potential usecases.
}