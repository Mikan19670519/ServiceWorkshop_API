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
	public class VehicleController : ControllerBase
	{
		protected readonly ILogger<VehicleController> _logger;
		protected readonly IVehicleService _vehicleService;

		public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
		{
			_logger = logger;
			_vehicleService = vehicleService;
		}

		[HttpPost("addvehicle")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post(VehicleModel model)
		{
			try
			{
				await _vehicleService.AddVehicleAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getvehicledetailsbyid")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetVehicleDetailsByUserId(VehicleModel model)
		{
			try
			{
				model = await _vehicleService.GetVehicleDetailsByIdAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getvehicles")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetVehicles()
		{
			try
			{
				List<VehicleModel> models = new List<VehicleModel>();
				models = await _vehicleService.GetVehicleDetailsAsync();

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("getvehiclesbyname/{vehicle}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetVehiclesByName(string vehicle)
		{
			try
			{
				List<VehicleModel> models = new List<VehicleModel>();
				models = await _vehicleService.GetFilteredByVehiclesAsync(vehicle);

				return Ok(models);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("updatevehicle")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Put(VehicleModel model)
		{
			try
			{
				await _vehicleService.UpdateVehicleDetailsAsync(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Source: { ex.Source }, Error Message: { ex.Message }");
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("deletevehicle")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(VehicleModel model)
		{
			try
			{
				await _vehicleService.RemoveVehicleAsync(model.VehicleID);

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
