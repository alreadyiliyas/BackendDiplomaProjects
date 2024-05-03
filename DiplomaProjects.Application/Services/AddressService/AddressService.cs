using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models.AddressModels;

namespace DiplomaProjects.Application.Services.AddressService
{
	public class AddressService : IAddressServices
	{
		private readonly IAddressRepositories<Countries> _countriesRepository;
		private readonly IAddressRepositories<Regions> _regionsRepository;

		public AddressService(IAddressRepositories<Countries> countriesRepository, IAddressRepositories<Regions> regionsRepository)
		{
			_countriesRepository = countriesRepository;
			_regionsRepository = regionsRepository;
		}

		public async Task<List<Countries>> GetAllCountries()
		{
			return await _countriesRepository.GetAll();
		}

		public async Task<int> AddCountry(Countries countries)
		{
			return await _countriesRepository.Create(countries);
		}

		public async Task<List<Regions>> GetAllRegionsByIdCountry(int id)
		{
			return await _regionsRepository.GetById(id);
		}
	}
}
