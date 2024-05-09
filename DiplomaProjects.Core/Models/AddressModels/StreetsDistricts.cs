namespace DiplomaProjects.Core.Models.AddressModels
{
	public class StreetsDistricts
	{
		public int StreetsId { get; set; }
		public int DistrictsId { get; set; }
		public StreetsDistricts(int streetsId, int districtsId)
		{
			StreetsId = streetsId;
			DistrictsId = districtsId;
		}
	}
}
