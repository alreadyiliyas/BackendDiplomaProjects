using AutoMapper.Configuration.Conventions;
using DiplomaProjects.Application.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DistrictsController : ControllerBase
	{
		private readonly IAddressServices _addressServices;
		public DistrictsController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}

		[HttpGet("{cityId}")]
		public async Task<IActionResult> GetAllDistrictsByIdCity(int cityId)
		{
			var districts = await _addressServices.GetAllDistrictsByIdCity(cityId);

			return Ok(districts);
		}
	}
}
