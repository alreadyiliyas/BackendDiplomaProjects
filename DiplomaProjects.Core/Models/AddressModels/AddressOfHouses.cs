﻿namespace DiplomaProjects.Core.Models.AddressModels
{
	public class AddressOfHouses
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string HouseNumber { get; set; }
		public string ApartmentNumber { get; set; }
		public int StreetsId { get; set; }
		public int MicroDistrictsId { get; set; }
		public AddressOfHouses(int id, int userId, string houseNumber, string apartmentNumber, int streetsId, int microDistrictsId) 
		{
			Id = id;
			UserId = userId;
			HouseNumber = houseNumber;
			ApartmentNumber = apartmentNumber;
			StreetsId = streetsId;		
			MicroDistrictsId = microDistrictsId;
		}
		public static (AddressOfHouses addressOfHouses, string error) Create(int id, int userId, string houseNumber, string apartmentNumber, int streetsId, int microDistrictsId)
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(houseNumber))
			{
				error = "Номер дома не может быть пустым";
			}
			else if (string.IsNullOrEmpty(apartmentNumber)) 
			{
				error = "Номер квартиры не может быть пустым";
			}
			var addressOfHouses = new AddressOfHouses(id, userId, houseNumber, apartmentNumber, streetsId, microDistrictsId);
			return (addressOfHouses, error);
		}
	}
}