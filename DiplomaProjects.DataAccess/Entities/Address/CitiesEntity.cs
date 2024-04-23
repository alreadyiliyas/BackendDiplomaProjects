namespace DiplomaProjects.DataAccess.Entities.Address
{
    public class CitiesEntity
    {
        public int Id { get; set; }
        public string? CitiesName { get; set; }
        public int RegionsId { get; set; }
        public RegionsEntity? Regions { get; set; }
    }
}
