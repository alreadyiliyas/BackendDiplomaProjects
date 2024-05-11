using DiplomaProjects.DataAccess.Entities.Address;

namespace DiplomaProjects.DataAccess.Entities.Users
{
    public class UserInfoEntity
    {
        public int Id { get; set; }
		public int UserId { get; set; }
		public UserEntity? User { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        //ИИН человека
        public string? IdentityNumberKZT { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }
    }
}
