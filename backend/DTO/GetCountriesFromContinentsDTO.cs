namespace backend.DTO;

//Wrapper class specifically for the response recieved from the GraphQL API when querying for Countries in a Continent.
public class GetCountriesFromContinentDTO
{
    public CountriesCollectionDTO Continent {get;set;}
}