namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class StreetsEntity
    {
        public int Id { get; set; }
        public string? StreetsName { get; set; }
		public ICollection<StreetDistrictsEntity> StreetDistricts { get; set; }
	}
}
