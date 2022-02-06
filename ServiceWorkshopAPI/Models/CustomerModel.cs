using ServiceWorkshopAPI.Data.Entities;
using System;
using System.Collections.Generic;

namespace ServiceWorkshopAPI.Models
{
	public class CustomerModel
	{
		public Guid CustomerId { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string ContactNumber { get; set; }

		public DateTime? DateAdded { get; set; }

		public DateTime? DateUpdated { get; set; }
	}
}