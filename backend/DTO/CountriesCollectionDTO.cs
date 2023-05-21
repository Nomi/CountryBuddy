using backend.Models;
namespace backend.DTO;

/// <summary>
/// Data-Transfer-Object for sending a collection of countries.
/// </summary>
public class CountriesCollectionDTO
{
    public List<Country> Countries {get;set;}
}