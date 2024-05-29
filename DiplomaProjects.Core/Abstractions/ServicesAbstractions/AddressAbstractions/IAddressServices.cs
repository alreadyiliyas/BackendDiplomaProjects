using DiplomaProjects.Core.Models.AddressModels;

namespace DiplomaProjects.Application.Services.AddressService
{
	public interface IAddressServices
	{
		Task<List<Countries>> GetAllCountries();
		Task<int> AddCountry(Countries countries);
		Task<List<Regions>> GetAllRegionsByIdCountry(int id);
		Task<List<Cities>> GetAllCitiesByIdRegion(int id);
		Task<List<Cities>> GetAllCititesByName(string name);
		Task<List<Districts>> GetAllDistrictsByIdCity(int id);
		Task<List<MicroDistricts>> GetAllMicroDistrictsByIdDistrict(int id);
		Task<List<Streets>> GetAllStreetsByIdDistrict(int id);
		Task<int> AddNewAddressOfHouses(AddressOfHouses addressOfHouses);
	}
}
