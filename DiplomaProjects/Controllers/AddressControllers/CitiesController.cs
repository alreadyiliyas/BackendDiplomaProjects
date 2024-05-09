using DiplomaProjects.Application.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CitiesController : ControllerBase
	{
		private readonly IAddressServices _addressService;
		public CitiesController(IAddressServices addressService)
		{
			_addressService = addressService;
		}
		[HttpGet("{regionId}")]
		public async Task<IActionResult> GetAllCitiesByIdRegions(int regionId)
		{
			var cities = await _addressService.GetAllCitiesByIdRegion(regionId);

			return Ok(cities);
		}
	}
}
