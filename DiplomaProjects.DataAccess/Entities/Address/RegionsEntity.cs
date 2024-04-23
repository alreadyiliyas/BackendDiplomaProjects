namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class RegionsEntity
    {
        public int Id { get; set; }
        public string? RegionsName { get; set; }
        public int CountryId { get; set; }
        public CountriesEntity? Countries { get; set; }
    }
}
