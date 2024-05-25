using DiplomaProjects.DataAccess.Entities.Users;
namespace DiplomaProjects.DataAccess.Entities.Application
{
	public class ApplicationsEntity
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int StatusesId { get; set; }
		public StatusesEntity Statuses { get; set; } = new StatusesEntity();
		public int ClientId { get; set; }
		public int? ModeratorId { get; set; }
		public int? EmployeeId { get; set; }
		public UserEntity Client { get; set; } = new UserEntity(); // Ссылка на клиента
		public UserEntity Moderator { get; set; } = new UserEntity(); // Ссылка на модератора
		public UserEntity Employee { get; set; } = new UserEntity();
		public DateTime CreatedAt { get; set; }
		public DateTime LastModifiedAt { get; set; }
		public List<string> ImagePaths { get; set; } = new List<string>();
	}
}
