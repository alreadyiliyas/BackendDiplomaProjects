using DiplomaProjects.Application.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MicroDistrictsController : ControllerBase
	{
		private readonly IAddressServices _addressServices;
		public MicroDistrictsController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}
		[HttpGet("{districtId}")]
		public async Task<IActionResult> GetAllMicroDistrictsByIdDistrict(int districtId)
		{
			var microDistricts = await _addressServices.GetAllMicroDistrictsByIdDistrict(districtId);

			return Ok(microDistricts);
		}

	}
}
