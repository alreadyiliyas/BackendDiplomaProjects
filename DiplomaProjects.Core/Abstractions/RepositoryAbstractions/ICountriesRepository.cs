using DiplomaProjects.Core.Models.AddressModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
	public interface ICountriesRepository
	{
		Task<bool> AddCountry(Countries country);
		Task<List<Countries>> GetAllCountries();
	}
}