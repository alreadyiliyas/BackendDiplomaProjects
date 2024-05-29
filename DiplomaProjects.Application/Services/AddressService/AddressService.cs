using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiplomaProjects.Application.Services.AddressService
{
	public class AddressService : IAddressServices
	{
		private readonly IRepositories<CountriesEntity> _countriesRepository;
		private readonly IRepositories<RegionsEntity> _regionsRepository;
		private readonly IRepositories<CitiesEntity> _cityRepository;
		private readonly IRepositories<DistrictsEntity> _districtRepository;
		private readonly IRepositories<MicroDistrictsEntity> _microDistrictsRepository;
		private readonly IRepositories<StreetDistrictsEntity> _streetsDistrictsRepository;
		private readonly IRepositories<StreetsEntity> _streetsRepository;
		private readonly IRepositories<AddressOfHouseEntity> _addressOfHousesRepository;
		private readonly IMapper _mapper;

		public AddressService(
			IRepositories<CountriesEntity> countriesRepository,
			IRepositories<RegionsEntity> regionsRepository,
			IRepositories<CitiesEntity> cityRepository,
			IRepositories<DistrictsEntity> districtsRepository,
			IRepositories<MicroDistrictsEntity> microDistrictsRepository,
			IRepositories<StreetsEntity> streetsRepository,
			IRepositories<StreetDistrictsEntity> streetsDistrictsRepository,
			IRepositories<AddressOfHouseEntity> addressOfHousesRepository,
			IMapper mapper)
		{
			_countriesRepository = countriesRepository;
			_regionsRepository = regionsRepository;
			_cityRepository = cityRepository;
			_districtRepository = districtsRepository;
			_microDistrictsRepository = microDistrictsRepository;
			_streetsRepository = streetsRepository;
			_streetsDistrictsRepository = streetsDistrictsRepository;
			_addressOfHousesRepository = addressOfHousesRepository;
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
		public async Task<List<Cities>> GetAllCitiesByIdRegion(int regionId)
		{
			Expression<Func<CitiesEntity, bool>> whereExp = r => r.RegionsId == regionId;
			Expression<Func<CitiesEntity, Cities>> selectExp = r => new Cities(r.Id, r.CitiesName);

			var citiesEntity = await _cityRepository.GetQueryDataAsync(whereExp, selectExp);
			return _mapper.Map<List<Cities>>(citiesEntity);
		}
		public async Task<List<Cities>> GetAllCititesByName(string name)
		{
			//Expression<Func<CitiesEntity, bool>> whereExp = c => c.CitiesName == name;
			//Expression<Func<CitiesEntity, Cities>> selectExp = r => new Cities(r.Id, r.CitiesName);
			return null;
		}
		
		public async Task<List<Districts>> GetAllDistrictsByIdCity(int cityId)
		{
			Expression<Func<DistrictsEntity, bool>> whereExp = r => r.CitiesId == cityId;
			Expression<Func<DistrictsEntity, Districts>> selectExp = r => new Districts(r.Id, r.DistrictsName);
			
			var citiesEntity = await _districtRepository.GetQueryDataAsync(whereExp, selectExp);
			return _mapper.Map<List<Districts>>(citiesEntity);
		}

		public async Task<List<MicroDistricts>> GetAllMicroDistrictsByIdDistrict(int districtId)
		{
			Expression<Func<MicroDistrictsEntity, bool>> whereExp = r => r.DistrictsId == districtId;
			Expression<Func<MicroDistrictsEntity, MicroDistricts>> selectExp = r => new MicroDistricts(r.Id, r.MicroDistrictsName);

			var microDistrictsEntity = await _microDistrictsRepository.GetQueryDataAsync(whereExp, selectExp);
			return _mapper.Map<List<MicroDistricts>>(microDistrictsEntity);
		}

		public async Task<List<Streets>> GetAllStreetsByIdDistrict(int districtId)
		{
			var streetsDistrictsEntity = await _streetsDistrictsRepository.GetQueryDataAsync(
				whereExp: sd => sd.DistrictsId == districtId,
				selectExp: sd => sd.StreetsId
				);

			var streetsEntity = await _streetsRepository.GetQueryDataAsync(
				whereExp: s => streetsDistrictsEntity.Contains(s.Id),
				selectExp: s => new Streets(s.Id, s.StreetsName)
				);

			var streets = _mapper.Map<List<Streets>>(streetsEntity);
			return streets;
		}

		public async Task<int> AddNewAddressOfHouses(AddressOfHouses addressOfHouses)
		{
			var addressOfHousesEntity = _mapper.Map<AddressOfHouseEntity>(addressOfHouses);
			if (_addressOfHousesRepository.Add(addressOfHousesEntity)) { return addressOfHousesEntity.Id; }
			else return -1;
		}
	}
}
