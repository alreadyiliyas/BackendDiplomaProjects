using DiplomaProjects.DataAccess.Entities.Address;
using DiplomaProjects.DataAccess.Entities.Application;
using DiplomaProjects.DataAccess.Entities.Users;

public class ApplicationsEntity
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public int StatusesId { get; set; }
	public StatusesEntity Statuses { get; set; }
	public int ClientId { get; set; }
	public int? ModeratorId { get; set; }
	public int? EmployeeId { get; set; }
	public UserEntity Client { get; set; }
	public UserEntity? Moderator { get; set; }
	public UserEntity? Employee { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime LastModifiedAt { get; set; }
	public List<string> ImagePaths { get; set; } = new List<string>();
	public int? CitiesId { get; set; } // Необязательное поле, если приложение может существовать без города
	public CitiesEntity? Cities { get; set; }
}
