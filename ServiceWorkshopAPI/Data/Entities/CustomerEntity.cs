using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceWorkshopAPI.Data.Entities
{
	public partial class CustomerEntity
	{
		[Key]
		public Guid CustomerID { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string ContactNumber { get; set; }

		public DateTime? DateAdded { get; set; }

		public DateTime? DateUpdated { get; set; }
	}
}
