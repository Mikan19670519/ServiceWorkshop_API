using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceWorkshopAPI.Data.Contracts;
using ServiceWorkshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		protected readonly ILogger<BookingController> _logger;
		protected readonly IBookingService _bookingService;

		public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
		{
			_logger = logger;
			_bookingService = bookingService;
		}

		[HttpPost("addbooking")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post(BookingModel model)
		{
			try
			{
				await _bookingService.AddBookingAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getbookingdetailsbyid")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetBookingDetailsByUserId(BookingModel model)
		{
			try
			{
				model = await _bookingService.GetBookingDetailsByIdAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getbookings")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetBookings()
		{
			try
			{
				List<BookingModel> models = new List<BookingModel>();
				models = await _bookingService.GetBookingDetailsAsync();

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getbookingsbycustomername/{customer}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetBookingsByName(string customer)
		{
			try
			{
				List<BookingModel> models = new List<BookingModel>();
				models = await _bookingService.GetFilteredBookingSummariesByCustomerAsync(customer);

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getbookingsbydaterange/{dateFrom}/{dateTo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetBookingsByDateRange(string dateFrom, string dateTo)
		{
			try
			{
				List<BookingModel> models = new List<BookingModel>();
				models = await _bookingService.GetFilteredBookingSummariesByDateRangeAsync(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo));

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("updatebooking")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Put(BookingModel model)
		{
			try
			{
				await _bookingService.UpdateBookingDetailsAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("deletebooking")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(BookingModel model)
		{
			try
			{
				await _bookingService.RemoveBookingAsync(model.BookingID);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}
	}
}
