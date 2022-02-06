using System;

namespace ServiceWorkshopAPI.Models
{
	public class VehicleModel
	{
		public Guid VehicleID { get; set; }

		public string Model { get; set; }

		public string Make { get; set; }

		public string RegNumber { get; set; }
	}
}