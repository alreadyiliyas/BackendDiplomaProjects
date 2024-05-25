using DiplomaProjects.Application.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/")]
	public class StreetsController : ControllerBase
	{
		private readonly IAddressServices _addressServices;
		public StreetsController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}
		[HttpGet("streets/{districtId}")]
		public async Task<IActionResult> GetAllStreetsByIdDistrict(int districtId) 
		{
			var streets = await _addressServices.GetAllStreetsByIdDistrict(districtId);

			return Ok(streets);
		}
	}
}
