using DiplomaProjects.Application.Services.AddressService;
using DiplomaProjects.Contracts.Address.Request;
using DiplomaProjects.Core.Models.AddressModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AddressOfHousesController : ControllerBase
	{
		private readonly IAddressServices _addressServices;
		public AddressOfHousesController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}
		[HttpPost]
		public async Task<IActionResult> AddNewAddressOfHouses([FromBody] AddressOfHousesRequest addressOfHousesRequest)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState); }

			var (addressOfHouse, error) = AddressOfHouses.Create(0, addressOfHousesRequest.HouseNumber, addressOfHousesRequest.ApartmentNumber, addressOfHousesRequest.StreetsId, addressOfHousesRequest.MicroDistrictsId);
			if (!string.IsNullOrEmpty(error))
			{
				return BadRequest(error);
			}
			
			var res = await _addressServices.AddNewAddressOfHouses(addressOfHouse);
			
			if (res != -1) { return Ok(res); }
			else { return BadRequest("Не получилось добавить адрес дома!"); }
		}
	}
}
