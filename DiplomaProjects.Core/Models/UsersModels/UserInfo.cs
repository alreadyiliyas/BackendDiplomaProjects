using System;
using System.Globalization;

namespace DiplomaProjects.Core.Models.UsersModels
{
	public class UserInfo
	{
		public int UserId { get; set; }
		public string? Surname { get; set; }
		public string? Name { get; set; }
		public DateTime BirthDate { get; set; }
		public string? PhoneNumber { get; set; }
		public string? IdentityNumberKZT { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastModifiedAt { get; set; }

		public UserInfo(int userId, string? surname, string? name, DateTime birthDate, string? phoneNumber, string? identityNumberKZT, DateTime createdAt, DateTime lastModifiedAt)
		{
			UserId = userId;
			Surname = surname;
			Name = name;
			BirthDate = birthDate.ToUniversalTime(); // Преобразование даты в UTC перед сохранением
			PhoneNumber = phoneNumber;
			IdentityNumberKZT = identityNumberKZT;
			CreatedAt = createdAt.ToUniversalTime(); // Преобразование даты в UTC перед сохранением
			LastModifiedAt = lastModifiedAt.ToUniversalTime(); // Преобразование даты в UTC перед сохранением
		}

		public static (UserInfo userInfo, string error) Create(int userId, string? surname, string? name, string birthDateString, string? phoneNumber, string? identityNumberKZT, DateTime createdAt, DateTime lastModifiedAt)
		{
			var error = string.Empty;
			if (userId == 0)
			{
				error = "UserId не может быть пустым!";
			}

			DateTime birthDate;
			if (!DateTime.TryParseExact(birthDateString, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
			{
				error = "Неверный формат даты рождения.";
			}

			var userInfo = new UserInfo(userId, surname, name, birthDate, phoneNumber, identityNumberKZT, createdAt, lastModifiedAt);
			return (userInfo, error);
		}
	}
}
