namespace DiplomaProjects.DataAccess.Entities.Address
{
	public class StreetDistrictsEntity
	{
		public int StreetsId { get; set; }
		public StreetsEntity Streets { get; set; }
		public int DistrictsId { get; set; }
		public DistrictsEntity Districts { get; set; }
	}
}
