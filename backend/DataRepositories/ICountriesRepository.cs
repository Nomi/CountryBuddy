using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;


namespace backend.DataRepositories
{
    /// <summary>
    /// Interface for a class using the Repository pattern to fetch data from our data source (in order to divide responsibilities).
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Get all continents from the data source.
        /// </summary>
        /// <returns>List of Continents.</returns>
        public Task<IEnumerable<Continent>> GetAllContinentsAsync();
        /// <summary>
        /// Get all countries from a specific continent.
        /// </summary>
        /// <param name="continentCode">The continent code of the concerned continent.</param>
        /// <returns>List of Countries in the specified Continent.</returns>
        public Task<IEnumerable<Country>> GetAllCountriesFromContinentAsync(String continentCode);
    }
}