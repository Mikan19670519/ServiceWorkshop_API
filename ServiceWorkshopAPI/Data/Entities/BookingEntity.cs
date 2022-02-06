using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceWorkshopAPI.Data.Entities
{
	public partial class BookingEntity
	{
		[Key]
		public Guid BookingID { get; set; }

		public Guid CustomerID { get; set; }

		public Guid VehicleID { get; set; }

		public DateTime Date { get; set; }

		public string Notes { get; set; }

		public virtual CustomerEntity Customer { get; set; }

		public virtual VehicleEntity Vehicle { get; set; }
	}
}
