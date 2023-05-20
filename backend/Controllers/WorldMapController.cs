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
    [ProducesResponseType(typeof(ContinentCollectionDTO), 200)]
    public async Task<IActionResult> GetAllContinents()
    {
        var result = await _countriesRepository.GetAllContinentsAsync();
        return Ok(new ContinentCollectionDTO{Continents=(List<Continent>)result});
    }
}
