using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Users
{
	public record UserInfoRequest(
		[Required] string Surname,
		[Required] string Name,
		[Required] DateTime BirthDate,
		[Required] string PhoneNumber,
		[Required] string IdentityNumberKZT,
		[Required] string Country,
		[Required] string Regions,
		[Required] string City,
		[Required] string Districts,
		[Required] string MicroDistrict,
		[Required] string Street,
		[Required] string HouseNumber,
		[Required] string ApartmentNumber
		);
}
