using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceWorkshopAPI.Data.Entities
{
	public partial class VehicleEntity
	{
		[Key]
		public Guid VehicleID { get; set; }

		public string Model { get; set; }

		public string Make { get; set; }

		public string RegNumber { get; set; }
	}
}
