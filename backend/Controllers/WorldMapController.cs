using Microsoft.AspNetCore.Mvc;
using backend.DataRepositories;
using backend.Models;
using backend.DTO;
using System.Net;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WorldMapController : ControllerBase
{
    private readonly ILogger<WorldMapController> _logger;
    private readonly ICountriesRepository _countriesRepository;
    public WorldMapController(ILogger<WorldMapController> logger, ICountriesRepository countriesRepository) //Handled by Dependancy Injection
    {
        _logger = logger;
        _countriesRepository = countriesRepository;
    }

    [HttpGet("GetAllContinents")]
    [ProducesResponseType(typeof(ContinentCollectionDTO), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllContinents()
    {
        var result = await _countriesRepository.GetAllContinentsAsync();
        return Ok(new ContinentCollectionDTO{Continents=(List<Continent>)result});
    }

    [HttpGet("GetCountriesFrom/{continentCode}/{limit}")]
    [ProducesResponseType(typeof(CountriesCollectionDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseMessageDTO), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseMessageDTO), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCountriesFrom(string continentCode, int limit)
    {
        if(limit<2||limit>10)
        {
            return BadRequest(new ResponseMessageDTO{Message="Limit should be >2 and <10."});
        }

        var result = await _countriesRepository.GetAllCountriesFromContinentAsync(continentCode);

        if(result!=null)
        {
            //Randomness and "limit" logic here.
            Random random = new Random();
            var countriesToReturn = new CountriesCollectionDTO();
            countriesToReturn.Countries=result.OrderBy(x => random.Next()).Take(limit).ToList();
            return Ok(countriesToReturn);
        }
        else
        {
            return NotFound(new ResponseMessageDTO{Message="No countries found. There might be an error in the parameters recieved."});
        }
    }
}
