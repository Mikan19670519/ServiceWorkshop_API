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
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		protected readonly ILogger<CustomerController> _logger;
		protected readonly ICustomerService _customerService;

		public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
		{
			_logger = logger;
			_customerService = customerService;
		}

		[HttpPost("addcustomer")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post(CustomerModel model)
		{
			try
			{
				await _customerService.AddCustomerAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getcustomerdetailsbyid")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetCustomerDetailsByUserId(CustomerModel model)
		{
			try
			{
				model = await _customerService.GetCustomerDetailsByIdAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getcustomers")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetCustomers()
		{
			try
			{
				List<CustomerModel> models = new List<CustomerModel>();
				models = await _customerService.GetCustomerDetailsAsync();

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getcustomersbyname/{customer}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetCustomersByName(string customer)
		{
			try
			{
				List<CustomerModel> models = new List<CustomerModel>();
				models = await _customerService.GetFilteredByCustomersAsync(customer);

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("updatecustomer")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Put(CustomerModel model)
		{
			try
			{
				await _customerService.UpdateCustomerDetailsAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("deletecustomer")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(CustomerModel model)
		{
			try
			{
				await _customerService.RemoveCustomerAsync(model.CustomerId);

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
