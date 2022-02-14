using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiceWorkshopAPI.Data.Contracts;
using ServiceWorkshopAPI.Data.DataContexts;
using ServiceWorkshopAPI.Data.Entities;
using ServiceWorkshopAPI.Models;
using ServiceWorkshopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Data.Services
{
	public class VehicleService : BaseService, IVehicleService
	{
		public VehicleService(ServiceWorkshopDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
		{
		}

		public async Task<VehicleModel> AddVehicleAsync(VehicleModel model)
		{
			try
			{
				var entityObject = await _dbContext.Vehicles
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.VehicleID == model.VehicleID);

				if (entityObject == null)
				{
					var vehicle = new VehicleEntity();
					vehicle.Make = model.Make;
					vehicle.Model = model.Model;
					vehicle.RegNumber = model.RegNumber;
					vehicle.VehicleID = model.VehicleID;

					_dbContext.Vehicles.Add(vehicle);

					await _dbContext.SaveChangesAsync();

					Guid max = _dbContext.Vehicles.Max(p => p.VehicleID);
					model.VehicleID = max;
				}
				else
				{
					await UpdateVehicleDetailsAsync(model);
				}

				return model;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}

		public async Task<VehicleModel> UpdateVehicleDetailsAsync(VehicleModel model)
		{
			try
			{
				var entityObject = await _dbContext.Vehicles
					.AsQueryable()
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.VehicleID == model.VehicleID);

				if (entityObject != null)
				{
					entityObject.Make = model.Make;
					entityObject.Model = model.Model;
					entityObject.RegNumber = model.RegNumber;
					entityObject.VehicleID = model.VehicleID;

					_dbContext.Vehicles.Update(entityObject);

					await _dbContext.SaveChangesAsync();
				}

				return model;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}

		public async Task<List<VehicleModel>> GetVehicleDetailsAsync()
		{
			try
			{
				List<VehicleModel> vehicles = await _dbContext.Vehicles
								.AsQueryable()
								.AsNoTracking()
								.Select(x => new VehicleModel
								{
									Make = x.Make,
									Model = x.Model,
									RegNumber = x.RegNumber,
									VehicleID = x.VehicleID
								}).ToListAsync();

				return vehicles;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}

		public async Task<VehicleModel> GetVehicleDetailsByIdAsync(VehicleModel model)
		{
			try
			{
				VehicleModel vehicle = await _dbContext.Vehicles
								.AsQueryable()
								.AsNoTracking()
								.Where(p => p.VehicleID == model.VehicleID)
								.Select(x => new VehicleModel
								{
									Make = x.Make,
									Model = x.Model,
									RegNumber = x.RegNumber,
									VehicleID = x.VehicleID
								}).FirstOrDefaultAsync();

				return vehicle;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}

		public async Task<bool> RemoveVehicleAsync(Guid id)
		{
			try
			{
				var entityObject = await _dbContext.Vehicles
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.VehicleID == id);

				if (entityObject != null)
				{
					_dbContext.Vehicles.Remove(entityObject);
					await _dbContext.SaveChangesAsync();
				}

				return true;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return false;
			}
		}

		public async Task<List<VehicleModel>> GetFilteredByVehiclesAsync(string vechile)
		{
			try
			{
				List<VehicleModel> vehicles = await _dbContext.Vehicles
					.AsQueryable()
					.AsNoTracking()
					.Where(x => x.Make.Contains(vechile.ToLower().Trim()))
					.Select(x => new VehicleModel
					{
						Make = x.Make,
						VehicleID = x.VehicleID,
						Model = x.Model,
						RegNumber = x.RegNumber
					}).ToListAsync();

				return vehicles;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return null;
			}
		}
	}
}