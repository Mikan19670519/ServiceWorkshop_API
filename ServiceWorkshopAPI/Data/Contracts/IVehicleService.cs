using ServiceWorkshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Data.Contracts
{
	public interface IVehicleService
	{
		Task<List<VehicleModel>> GetVehicleDetailsAsync();
		Task<VehicleModel> GetVehicleDetailsByIdAsync(VehicleModel model);
		Task<VehicleModel> UpdateVehicleDetailsAsync(VehicleModel model);
		Task<VehicleModel> AddVehicleAsync(VehicleModel model);
		Task<bool> RemoveVehicleAsync(Guid id);
		Task<List<VehicleModel>> GetFilteredByVehiclesAsync(string vechile);
	}
}
