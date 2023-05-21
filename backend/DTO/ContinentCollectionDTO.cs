using backend.Models;
namespace backend.DTO;

/// <summary>
/// Data-Transfer-Object for sending a collection of continents.
/// </summary>
public class ContinentCollectionDTO
{
    public List<Continent> Continents {get;set;}
}