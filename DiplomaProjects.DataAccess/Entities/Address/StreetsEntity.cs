namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class StreetsEntity
    {
        public int Id { get; set; }
        public string? StreetsName { get; set; }
        public int MicroDistrictId { get; set; }
        public MicroDistrictsEntity? MicroDistricts { get; set; }
    }
}
