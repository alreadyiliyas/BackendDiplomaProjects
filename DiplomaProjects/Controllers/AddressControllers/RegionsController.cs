﻿using DiplomaProjects.Application.Services.AddressService;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.AddressControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RegionsController : ControllerBase
	{
		private readonly IAddressServices _addressServices;
		public RegionsController(IAddressServices addressServices)
		{
			_addressServices = addressServices;
		}
		[HttpGet("{countryId}")]

		public async Task<IActionResult> GetAllRegionsByIdCountry(int countryId)
		{
			var regions = await _addressServices.GetAllRegionsByIdCountry(countryId);

			return Ok(regions);
		}
	}
}
