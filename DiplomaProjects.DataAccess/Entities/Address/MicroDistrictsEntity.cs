﻿namespace DiplomaProjects.DataAccess.Entities.Address
{
	public class MicroDistrictsEntity
	{
		public int Id { get; set; }
		public string? MicroDistrictsName { get; set; }
		public int DistrictId { get; set; }
		public DistrictsEntity? Districts { get; set; }
	}
}
