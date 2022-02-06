using ServiceWorkshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Data.Contracts
{
	public interface IBookingService
	{
		Task<List<BookingModel>> GetBookingDetailsAsync();
		Task<BookingModel> GetBookingDetailsByIdAsync(BookingModel model);
		Task<BookingModel> AddBookingAsync(BookingModel model);
		Task<BookingModel> UpdateBookingDetailsAsync(BookingModel model);
		Task<bool> RemoveBookingAsync(Guid id);
		Task<List<BookingModel>> GetFilteredBookingSummariesByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<List<BookingModel>> GetFilteredBookingSummariesByCustomerAsync(string customer);
		Task<List<BookingModel>> GetFilteredBookingSummariesByVehicleAsync(string vehicle);
	}
}
