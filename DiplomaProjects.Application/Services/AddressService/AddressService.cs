using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.DataAccess.Entities.Address;
using System.Linq.Expressions;

namespace DiplomaProjects.Application.Services.AddressService
{
	public class AddressService : IAddressServices
	{
		private readonly IRepositories<CountriesEntity> _countriesRepository;
		private readonly IRepositories<RegionsEntity> _regionsRepository;
		private readonly IMapper _mapper;

		public AddressService(
			IRepositories<CountriesEntity> countriesRepository, 
			IRepositories<RegionsEntity> regionsRepository,
			IMapper mapper)
		{
			_countriesRepository = countriesRepository;
			_regionsRepository = regionsRepository;
			_mapper = mapper;
		}

		public async Task<int> AddCountry(Countries country)
		{
			var countryEntity = _mapper.Map<CountriesEntity>(country);
			if (_countriesRepository.Add(countryEntity))
				return countryEntity.Id;
			else
				return -1;
		}

		public async Task<List<Countries>> GetAllCountries()
		{
			var countryEntities = _countriesRepository.GetAll();
			return _mapper.Map<List<Countries>>(countryEntities);
		}

		public async Task<List<Regions>> GetAllRegionsByIdCountry(int countryId)
		{
			Expression<Func<RegionsEntity, bool>> whereExp = r => r.CountriesId == countryId;
			Expression<Func<RegionsEntity, Regions>> selectExp = r => new Regions(r.Id, r.RegionsName);

			var regionsEntity = await _regionsRepository.GetQueryDataAsync(whereExp, selectExp);
			return _mapper.Map<List<Regions>>(regionsEntity);
		}
	}
}
