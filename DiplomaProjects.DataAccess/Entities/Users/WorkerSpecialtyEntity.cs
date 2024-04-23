namespace DiplomaProjects.DataAccess.Entities.Users
{
	public class WorkerSpecialtyEntity
	{
		public int WorkerId { get; set; }
		public WorkerInfoEntity Worker { get; set; }

		public int SpecialtyId { get; set; }
		public SpecialtiesEntity Specialty { get; set; }
	}
}
