namespace DiplomaProjects.Core.Models.ApplicationsModels
{
	public class Statuses
	{
		public int Id { get; set; }
		public string? StatusesName { get; set; }
		public Statuses(int id, string? statusesName)
		{
			Id = id;
			StatusesName = statusesName;
		}
		public static (Statuses statuses, string error) Create(int id, string statusesName)
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(statusesName))
			{
				error = "Статус не может быть пустым";
			}
			var statuses = new Statuses(id, statusesName);
			return (statuses, error);
		}
	}
}
