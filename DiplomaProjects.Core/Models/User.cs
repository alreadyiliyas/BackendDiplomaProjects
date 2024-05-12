using Microsoft.AspNetCore.Identity;

namespace DiplomaProjects.Core.Models
{
	public class User : IdentityUser
	{
		public const int MAX_USERNAME_LENGTH = 30;
		public const int MIN_USERNAME_LENGTH = 4;
		
		private User(int id, Guid guidUserId, string email, string passwordHash, int userRoleId)
		{
			Id = id;
			GuidUserId = guidUserId;
			Email = email;
			PasswordHash = passwordHash;
			UserRoleId = userRoleId;
		}
		public new int Id { get; }
		public Guid GuidUserId { get; }
		public new string? UserName { get; } = string.Empty;
		public new string? Email { get; } = string.Empty;
		public new string? PasswordHash { get; } = string.Empty;
		public int UserRoleId { get; }
		public virtual Role UserRole { get; }
		public string? UserRoleName { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		private User() { }
		public static (User User, string Error) Create(int id, Guid guidUserId, string email, string passwordHash, int userRoleId)
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
				error += "Password can't be empty";
			}
			var user = new User(id, guidUserId, email, passwordHash, userRoleId);
			return (user, error);
		}
	}
}
