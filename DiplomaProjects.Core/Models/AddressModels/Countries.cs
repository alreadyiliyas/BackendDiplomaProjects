namespace DiplomaProjects.Core.Models.AddressModels
{
	public class Countries
	{
		private Countries(int id, string countriesName)
		{
			Id = id;
			CountriesName = countriesName;
		}

		public int Id { get; set; }
		public string CountriesName { get; set; }

		public static (Countries countries, string error) Create(int id, string countriesName)
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(countriesName))
			{
				error = "Название страны не может быть пустым!";
			}
			var country = new Countries(id, countriesName);
			return (country, error);
		}
	}
}
