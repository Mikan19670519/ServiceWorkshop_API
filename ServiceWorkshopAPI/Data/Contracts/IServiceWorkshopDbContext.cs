using Microsoft.EntityFrameworkCore;
using ServiceWorkshopAPI.Data.Entities;

namespace ServiceWorkshopAPI.Data.Contracts
{
	public interface IServiceWorkshopDbContext
	{
		DbSet<BookingEntity> Bookings { get; set; }
		DbSet<CustomerEntity> Customers { get; set; }
		DbSet<VehicleEntity> Vehicles { get; set; }
	}
}
