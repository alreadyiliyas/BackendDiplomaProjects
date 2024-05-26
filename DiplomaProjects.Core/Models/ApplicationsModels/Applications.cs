using DiplomaProjects.Core.Models.ApplicationsModels;
using DiplomaProjects.Core.Models;
public class Applications
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public int StatusesId { get; set; }
	public int ClientId { get; set; }
	public int? ModeratorId { get; set; }
	public int? EmployeeId { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime LastModifiedAt { get; set; }
	public Statuses Statuses { get; set; }
	public User Client { get; set; }
	public User? Moderator { get; set; }
	public User? Employee { get; set; }
	public List<string> ImagePaths { get; set; } = new List<string>();

	public Applications(int id, string? title, string? description, Statuses statuses, int clientId, int? moderatorId, int? employeeId, DateTime createdAt, DateTime lastModifiedAt, List<string> imagePaths)
	{
		Id = id;
		Title = title;
		Description = description;
		Statuses = statuses;
		ClientId = clientId;
		ModeratorId = moderatorId;
		EmployeeId = employeeId;
		CreatedAt = createdAt.ToUniversalTime();
		LastModifiedAt = lastModifiedAt.ToUniversalTime();
		ImagePaths = imagePaths;
	}

	public static (Applications applications, string error) Create(int id, string? title, string? description, Statuses statuses, int clientId, int? moderatorId, int? employeeId, DateTime createdAt, DateTime lastModifiedAt, List<string> imagePaths)
	{
		var error = string.Empty;
		if (string.IsNullOrWhiteSpace(title))
		{
			error = "Заголовок не может быть пустым";
		}
		else if (string.IsNullOrEmpty(description))
		{
			error = "Описание не может быть пустым";
		}
		var applications = new Applications(id, title, description, statuses, clientId, moderatorId, employeeId, createdAt, lastModifiedAt, imagePaths);
		return (applications, error);
	}
}
