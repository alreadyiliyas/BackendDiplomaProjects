using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Address.Request
{
	public record CountriesRequest(
		[Required] string CountryName
	);
}
    