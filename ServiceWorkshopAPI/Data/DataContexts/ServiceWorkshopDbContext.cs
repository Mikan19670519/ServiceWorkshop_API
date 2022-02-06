using Microsoft.EntityFrameworkCore;
using ServiceWorkshopAPI.Data.Contracts;
using ServiceWorkshopAPI.Data.Entities;

namespace ServiceWorkshopAPI.Data.DataContexts
{
	public class ServiceWorkshopDbContext : DbContext, IServiceWorkshopDbContext
	{
		public ServiceWorkshopDbContext(DbContextOptions<ServiceWorkshopDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		public virtual DbSet<BookingEntity> Bookings { get; set; }
		public virtual DbSet<CustomerEntity> Customers { get; set; }
		public virtual DbSet<VehicleEntity> Vehicles { get; set; }
	}
}
