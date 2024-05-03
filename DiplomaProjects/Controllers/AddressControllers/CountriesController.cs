using DiplomaProjects.Application.Services.AddressService;
using DiplomaProjects.Contracts.Address.Request;
using DiplomaProjects.Contracts.Address.Response;
using DiplomaProjects.Core.Models.AddressModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressEnpoints
{
    //[Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class CountriesController : ControllerBase
	{
		private readonly IAddressServices _addressServices;

		public CountriesController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}
		[HttpGet("countries")]
		public async Task<ActionResult<AddressResponse>> GetCountries()
		{
			var countries = await _addressServices.GetAllCountries();

			var response = countries.Select(c => new AddressResponse(c.Id, c.CountriesName));

			return Ok(response);
		}
		[HttpPost("countries")]
		public async Task<ActionResult<int>> AddCountry([FromBody] CountriesRequest request)
		{
			var (country, error) = Countries.Create(0, request.CountryName);
			
			if (!string.IsNullOrEmpty(error))
			{
				return BadRequest(error);
			}
			var countryId = await _addressServices.AddCountry(country);

			return Ok(countryId);
		}
		//update
		//delete
	}
}
