namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class DistrictsEntity
    {
        public int Id { get; set; }
        public string? DistrictsName { get; set; }
        public int CitiesId { get; set; }
        public CitiesEntity? Cities { get; set; }
		public ICollection<StreetDistrictsEntity> StreetDistricts { get; set; }
	}
}
