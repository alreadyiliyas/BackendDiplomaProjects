namespace DiplomaProjects.Core.Models.AddressModels
{
	public class Districts
	{
		public int Id { get; set; }
		public string DistrictsName { get; set; }

		public Districts(int id, string districtsName) 
		{
			Id = id;
			DistrictsName = districtsName;
		}

		public static (Districts districts, string districtsName) Create (int id, string districtsName)
		{
			var error = string.Empty;

			if (string.IsNullOrWhiteSpace(districtsName))
			{
				error = "Название района не может быть пустым";
			}

			var districts = new Districts(id, districtsName);
			return (districts, error);
		}
	}
}
