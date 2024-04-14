namespace DiplomaProjects.DataAccess.Entities
{
	public class UserEntity 
	{
		public int Id { get; set; }
		public Guid GuidUserId { get; set; }
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public int UserRoleId { get; set; }
		public RoleEntity? UserRole { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
	}
}
