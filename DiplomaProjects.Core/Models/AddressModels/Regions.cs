namespace DiplomaProjects.Core.Models.AddressModels
{
	public class Regions
	{
		private Regions(int id, string regionsName)
		{
			Id = id;
			RegionsName = regionsName;
		}

		public int Id { get; set; }
		public string RegionsName { get; set; }

		public static (Regions regions, string error) Create(int id, string regionsName)
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(regionsName))
			{
				error = "Название региона не может быть пустым!";
			}
			var regions = new Regions(id, regionsName);
			return (regions, error);
		}
	}
}
