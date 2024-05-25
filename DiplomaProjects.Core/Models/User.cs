using Microsoft.AspNetCore.Identity;

namespace DiplomaProjects.Core.Models
{
	public class User : IdentityUser<int>
	{
		public const int MAX_USERNAME_LENGTH = 30;
		public const int MIN_USERNAME_LENGTH = 4;

		public Guid GuidUserId { get; private set; }
		public int UserRoleId { get; private set; }
		public virtual Role UserRole { get; private set; }
		public string? UserRoleName { get; private set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		private User() { }
		public static (User User, string Error) Create(string email, string passwordHash, int userRoleId, string userRoleName)
		{
			var error = string.Empty;

			if (string.IsNullOrEmpty(email) || email.Length > MAX_USERNAME_LENGTH || email.Length < MIN_USERNAME_LENGTH)
			{
				error = "Email can't be empty or longer than 30 symbols or shorter than 4 symbols";
			}
			if (string.IsNullOrEmpty(passwordHash))
			{
				if (!string.IsNullOrEmpty(error))
				{
					error += "\n";
				}
				error += "Пароль не может быть пустым";
			}

			var user = new User
			{
				GuidUserId = Guid.NewGuid(),
				Email = email,
				PasswordHash = passwordHash,
				UserRoleId = userRoleId,
				UserRoleName = userRoleName
			};

			return (user, error);
		}
	}
}
