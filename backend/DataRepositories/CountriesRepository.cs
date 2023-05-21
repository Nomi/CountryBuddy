using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.DTO;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace backend.DataRepositories
{
    /// <summary>
    /// (Concrete) Implementation of the ICountriesRepository that provides the logic for fetching data from the specified GraphQL API (our data source).
    /// Read more about it on ICountriesRepository.
    /// </summary>
    public class CountriesRepository : ICountriesRepository
    {
        /// <summary>
        /// Stores an instance of a GraphQL Client. 
        /// The URL the client interacts with can be changed in appsettings.json (the value is read and set in Program.cs).
        /// </summary>
        private readonly IGraphQLClient _client;

        /// <summary>
        /// Constructor for the class. Sets the "_client" member using dependancy injection.
        /// </summary>
        /// <param name="client">An instance of a GraphQL Client (passed/typecasted as its interface)</param>
        public CountriesRepository(IGraphQLClient client)
        {
            _client = client;
        }
        /// <summary>
        /// Implementation of a method from the interface. 
        /// Interacts with the GraphQL Client "_client" to get all continents in an Asynchronous fashion.
        /// </summary>
        /// <returns>List of all continents returned by the specified GraphQL API. If an error occurs, returns NULL.</returns>
        public async Task<IEnumerable<Continent>> GetAllContinentsAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        query allContinents{
                            continents {
                                code
                                name
                            }
                        }"
            };

            var response = await _client.SendQueryAsync<ContinentCollectionDTO>(query);
            return response.Data.Continents;
        }
        /// <summary>
        /// Implementation of a method from the interface. 
        /// Interacts with the GraphQL Client "_client" to get all countries in the specified continent in an Asynchronous fashion.
        /// </summary>
        /// <param name="continentCode">The code of the continent whose countries need to be fetched.</param>
        /// <returns>List of Countries in the specified continent.</returns>
        public async Task<IEnumerable<Country>> GetAllCountriesFromContinentAsync(String continentCode)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        query countriesFromContinent{
                            continent(code: "+$"\"{continentCode}\""+@") {
                                countries {
                                    code
                                    name
                                    currency
                                    phone
                                    continent {
                                        code
                                        name
                                    }
                                    languages {
                                        name
                                    }
                                }
                            }
                        }"
            };

            var response = await _client.SendQueryAsync<GetCountriesFromContinentDTO>(query);
            return response.Data.Continent.Countries;
        }
    }
}