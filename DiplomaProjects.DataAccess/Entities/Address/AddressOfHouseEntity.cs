namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class AddressOfHouseEntity
    {
        public int Id { get; set; }
        public string? HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public int StreetId { get; set; }
        public StreetsEntity? Streets { get; set; }
    }
}
