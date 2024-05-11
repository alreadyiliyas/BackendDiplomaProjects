using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Address.Request
{
	public record AddressOfHousesRequest(
		[Required] int UserId,
		[Required] int MicroDistrictsId,
		[Required] int StreetsId,
		[Required] string HouseNumber,
		[Required] string ApartmentNumber
		);
}
