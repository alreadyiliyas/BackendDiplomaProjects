namespace DiplomaProjects.Core.Models.AddressModels
{
	public class Cities
	{
		public int Id { get; set; }
		public string CitiesName { get; set; }

		public Cities(int id, string citiesName) 
		{
			Id = id;
			CitiesName = citiesName;
		}

		public static (Cities cities, string error) Create(int id, string citiesName)
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(citiesName))
			{
				error = "Название города не может быть пустым!";
			}
			var cities = new Cities(id, citiesName);
			return (cities, error);
		}

	}
}
