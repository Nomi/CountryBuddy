using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;


namespace backend.DataRepositories
{
    public interface ICountriesRepository
    {
        public Task<IEnumerable<Continent>> GetAllContinentsAsync();
    }
}