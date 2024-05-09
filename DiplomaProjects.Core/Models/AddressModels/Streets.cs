namespace DiplomaProjects.Core.Models.AddressModels
{
	public class Streets
	{
		public int Id { get; set; }
		public string StreetsName { get; set; }
		public Streets(int id, string streetsName)
		{
			Id = id;
			StreetsName = streetsName;
		}

		public (Streets streets, string streetsName) Create(int id, string streetsName) 
		{
			var error = string.Empty;
			if (string.IsNullOrWhiteSpace(streetsName))
			{
				error = "Название улиц не может быть пустым";
			}

			var streets = new Streets(id, streetsName);
			return (streets, error);
		}
	}
}
