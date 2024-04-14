using Microsoft.AspNetCore.Identity;

namespace DiplomaProjects.Core.Models
{
	public class User : IdentityUser
	{
		public const int MAX_USERNAME_LENGTH = 30;
		public const int MIN_USERNAME_LENGTH = 4;
		
		private User(int id, Guid guidUserId, string userName, string email, string passwordHash, int userRoleId)
		{
			Id = id;
			GuidUserId = guidUserId;
			UserName = userName;
			Email = email;
			PasswordHash = passwordHash;
			UserRoleId = userRoleId;
		}
		public int Id { get; }
		public Guid GuidUserId { get; }
		public string UserName { get; } = string.Empty;
		public string Email { get; } = string.Empty;
		public string PasswordHash { get; } = string.Empty;
		public int UserRoleId { get; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		
		public static (User User, string Error) Create(int id, Guid guidUserId, string userName, string email, string passwordHash, int userRoleId)
		{
			var error = string.Empty;

			if (string.IsNullOrEmpty(userName) || userName.Length > MAX_USERNAME_LENGTH || userName.Length < MIN_USERNAME_LENGTH)
			{
				error = "UserName can't be empty or longer than 30 symbols or shorter than 4 symbols";
			}
			if (string.IsNullOrEmpty(passwordHash))
			{
				if (!string.IsNullOrEmpty(error))
				{
					error += "\n";
				}
				error += "Password can't be empty";
			}

			var user = new User(id, guidUserId, userName, email, passwordHash, userRoleId);
			return (user, error);
		}
	}
}
