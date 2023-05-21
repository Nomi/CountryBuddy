namespace backend.DTO;

//Wrapper class specifically for the response recieved from the GraphQL API when querying for Countries in a Continent.
/// <summary>
/// Data-Transfer-Object for the method used to fetch countries of a continent from the provided GraphQL API.
/// </summary>
public class GetCountriesFromContinentDTO
{
    public CountriesCollectionDTO Continent {get;set;}
}