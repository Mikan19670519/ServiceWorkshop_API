using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceWorkshopAPI.Data.Contracts;
using ServiceWorkshopAPI.Data.DataContexts;
using ServiceWorkshopAPI.Data.Entities;
using ServiceWorkshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Data.Services
{
	public class BookingService : IBookingService
	{
		private readonly ServiceWorkshopDbContext _dbContext;
		private readonly IMapper _mapper;
		protected readonly ILogger<BookingService> _logger;

		public BookingService(ServiceWorkshopDbContext dbContext, IMapper mapper, ILogger<BookingService> logger)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<BookingModel> AddBookingAsync(BookingModel model)
		{
			try
			{
				var entityObject = await _dbContext.Bookings
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.BookingID == model.BookingID);

				if (entityObject == null)
				{
					var booking = new BookingEntity();
					booking.Date = model.BookingDate;
					booking.Notes = model.Notes;
					booking.CustomerID = model.CustomerID;
					booking.VehicleID = model.VehicleID;

					_dbContext.Bookings.Add(booking);

					await _dbContext.SaveChangesAsync();

					Guid max = _dbContext.Bookings.Max(p => p.BookingID);
					model.BookingID = max;
				}
				else
				{
					await UpdateBookingDetailsAsync(model);
				}

				return model;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<BookingModel> UpdateBookingDetailsAsync(BookingModel model)
		{
			try
			{
				var entityObject = await _dbContext.Bookings
					.AsQueryable()
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.BookingID == model.BookingID);

				if (entityObject != null)
				{
					entityObject.Date = model.BookingDate;
					entityObject.Notes = model.Notes;
					entityObject.CustomerID = model.CustomerID;
					entityObject.VehicleID = model.VehicleID;

					_dbContext.Bookings.Update(entityObject);

					await _dbContext.SaveChangesAsync();
				}

				return model;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<List<BookingModel>> GetBookingDetailsAsync()
		{
			try
			{
				List<BookingModel> bookings = await _dbContext.Bookings
					.Include(x => x.Customer)
					.Include(x => x.Vehicle)
					.AsQueryable()
					.AsNoTracking()
					.Select(x => new BookingModel
					{
						BookingID = x.BookingID,
						BookingDate = x.Date,
						Notes = x.Notes,
						CustomerName = x.Customer.Name,
						RegistrationNo = x.Vehicle.RegNumber,
						CustomerContactNumber = x.Customer.ContactNumber,
						VehicleMake = x.Vehicle.Make,
						VehicleModel = x.Vehicle.Model,
						Customer = x.Customer,
						Vehicle = x.Vehicle,
						VehicleID = x.Vehicle.VehicleID,
						CustomerID = x.Customer.CustomerID
					}).ToListAsync();

				return bookings;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<BookingModel> GetBookingDetailsByIdAsync(BookingModel model)
		{
			try
			{
				BookingModel booking = await _dbContext.Bookings
					.Include(x => x.Customer)
					.Include(x => x.Vehicle)
					.AsQueryable()
					.AsNoTracking()
					.Where(p => p.BookingID == model.BookingID)
					.Select(x => new BookingModel
					{
						BookingID = x.BookingID,
						BookingDate = x.Date,
						Notes = x.Notes,
						CustomerName = x.Customer.Name,
						RegistrationNo = x.Vehicle.RegNumber,
						CustomerContactNumber = x.Customer.ContactNumber,
						VehicleMake = x.Vehicle.Make,
						VehicleModel = x.Vehicle.Model,
						Customer = x.Customer,
						Vehicle = x.Vehicle,
						VehicleID = x.Vehicle.VehicleID,
						CustomerID = x.Customer.CustomerID
					}).FirstOrDefaultAsync();

				return booking;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<bool> RemoveBookingAsync(Guid id)
		{
			try
			{
				var entityObject = await _dbContext.Bookings
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.BookingID == id);

				if (entityObject != null)
				{
					_dbContext.Bookings.Remove(entityObject);
					await _dbContext.SaveChangesAsync();
				}

				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return false;
			}
		}

		public async Task<List<BookingModel>> GetFilteredBookingSummariesByDateRangeAsync(DateTime startDate, DateTime endDate)
		{
			try
			{
				List<BookingModel> bookings = await _dbContext.Bookings
					.Include(x => x.Customer)
					.Include(x => x.Vehicle)
					.AsQueryable()
					.AsNoTracking()
					.Where(p => p.Date >= startDate && p.Date <= endDate)
					.Select(x => new BookingModel
					{
						BookingID = x.BookingID,
						BookingDate = x.Date,
						Notes = x.Notes,
						CustomerName = x.Customer.Name,
						RegistrationNo = x.Vehicle.RegNumber,
						CustomerContactNumber = x.Customer.ContactNumber,
						VehicleMake = x.Vehicle.Make,
						VehicleModel = x.Vehicle.Model,
						Customer = x.Customer,
						Vehicle = x.Vehicle,
						VehicleID = x.Vehicle.VehicleID,
						CustomerID = x.Customer.CustomerID
					}).ToListAsync();

				return bookings;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<List<BookingModel>> GetFilteredBookingSummariesByCustomerAsync(string customer)
		{
			try
			{
				List<BookingModel> bookings = await _dbContext.Bookings
					.Include(x => x.Customer)
					.AsQueryable()
					.AsNoTracking()
					.Where(x => x.Customer.Name.Contains(customer.ToLower().Trim()))
					.Select(x => new BookingModel
					{
						BookingID = x.BookingID,
						BookingDate = x.Date,
						Notes = x.Notes,
						CustomerName = x.Customer.Name,
						RegistrationNo = x.Vehicle.RegNumber,
						CustomerContactNumber = x.Customer.ContactNumber,
						VehicleMake = x.Vehicle.Make,
						VehicleModel = x.Vehicle.Model,
						Customer = x.Customer,
						Vehicle = x.Vehicle,
						VehicleID = x.Vehicle.VehicleID,
						CustomerID = x.Customer.CustomerID
					}).ToListAsync();

				return bookings;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<List<BookingModel>> GetFilteredBookingSummariesByVehicleAsync(string vechile)
		{
			try
			{
				List<BookingModel> bookings = await _dbContext.Bookings
					.Include(x => x.Vehicle)
					.AsQueryable()
					.AsNoTracking()
					.Where(x => x.Vehicle.Make.Contains(vechile.ToLower().Trim()))
					.Select(x => new BookingModel
					{
						BookingID = x.BookingID,
						BookingDate = x.Date,
						Notes = x.Notes,
						CustomerName = x.Customer.Name,
						RegistrationNo = x.Vehicle.RegNumber,
						CustomerContactNumber = x.Customer.ContactNumber,
						VehicleMake = x.Vehicle.Make,
						VehicleModel = x.Vehicle.Model,
						Customer = x.Customer,
						Vehicle = x.Vehicle,
						VehicleID = x.Vehicle.VehicleID,
						CustomerID = x.Customer.CustomerID
					}).ToListAsync();

				return bookings;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}
	}
}