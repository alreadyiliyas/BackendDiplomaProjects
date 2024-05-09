namespace DiplomaProjects.Core.Models.AddressModels
{
	public class MicroDistricts
	{
		public int Id { get; set; }
		public string MicroDistrictsName { get; set; }
		public MicroDistricts(int id, string microDistrictsName) 
		{
			Id = id;
			MicroDistrictsName = microDistrictsName;
		}
		public static (MicroDistricts microDistricts, string microDistrictsName) Create(int id, string microDistrictsName)
		{
			var error = string.Empty;


			if (string.IsNullOrWhiteSpace(microDistrictsName))
			{
				error = "Название микрорайона не может быть пустым";
			}

			var microDistricts = new MicroDistricts(id, microDistrictsName);
			return (microDistricts, error);
		}

	}
}
