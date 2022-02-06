using ServiceWorkshopAPI.Data.Entities;
using System;
using System.Collections.Generic;

namespace ServiceWorkshopAPI.Models
{
	public class CustomersVehicleBookingModel
	{
		public Guid ID { get; set; }
		public Guid CustomerID { get; set; }
		public Guid VehicleID { get; set; }
		public Guid BookingID { get; set; }

		public List<BookingModel> Bookings { get; set; }
		public List<CustomerModel> Customers { get; set; }
		public List<VehicleModel> Vehicles { get; set; }
	}
}
