using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.DTO;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace backend.DataRepositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly IGraphQLClient _client;

        public CountriesRepository(IGraphQLClient client) //Handled via Dependancy Injection.
        {
            _client = client;
        }
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
    }
}