using DiplomaProjects.Core.Models.AddressModels;

namespace DiplomaProjects.Application.Services.AddressService
{
	public interface IAddressServices
	{
		Task<List<Countries>> GetAllCountries();
		Task<int> AddCountry(Countries countries);
		Task<List<Regions>> GetAllRegionsByIdCountry(int id);
	}
}
