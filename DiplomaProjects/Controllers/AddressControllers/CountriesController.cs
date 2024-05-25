using DiplomaProjects.Application.Services.AddressService;
using DiplomaProjects.Contracts.Address.Request;
using DiplomaProjects.Core.Models.AddressModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressEnpoints
{
    //[Authorize]
    [ApiController]
	[Route("api/")]
	public class CountriesController : ControllerBase
	{
		private readonly IAddressServices _addressService;

		public CountriesController(IAddressServices addressService)
		{
			_addressService = addressService;
		}
		[HttpGet("countries")]
		public async Task<IActionResult> GetAllCountries()
		{
			var countries = await _addressService.GetAllCountries();
			return Ok(countries); // Возвращаем список стран
		}
		[HttpPost("countries")]
		public async Task<IActionResult> AddCountry([FromBody] CountriesRequest countryRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var (country, error) = Countries.Create(0, countryRequest.CountryName); // ID необходимо указать, но можно заменить на 0 или другое значение по умолчанию
			if (!string.IsNullOrEmpty(error))
			{
				return BadRequest(error);
			}

			var result = await _addressService.AddCountry(country);
			if (result != -1)
			{
				return Ok(result); // Возвращаем ID добавленной страны
			}
			else
			{
				return BadRequest("Failed to add country");
			}
		}
		//update
		//delete
	}
}
