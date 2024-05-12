namespace DiplomaProjects.Core.Models
{
	public class Role
	{
		private const int MAX_ROLENAME_LENGTH = 20;
		private Role(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; }
		public string Name { get; } = string.Empty;

		public static (Role Role, string Error) Create(int id, string name)
		{
			var error = string.Empty;

			if (string.IsNullOrEmpty(name) || name.Length > MAX_ROLENAME_LENGTH)
			{
				error = "Роль не может быть длиннее, чем 20 символов";
			} 

			var role = new Role(id, name);
			return (role, error);
		}
	}
}
