namespace DiplomaProjects.DataAccess.Entities.Users
{
    public class WorkerInfoEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
		public ICollection<WorkerSpecialtyEntity> Specialties { get; set; }
	}
}
