namespace backend.Models;

/// <summary>
/// "Model" class for representation of a Continent (excluding its code, which seems to be NULL for every language on the specified GraphQL API).
/// </summary>
public class Language
{
    // public String Code {get;set;}
    public String Name {get;set;}
}