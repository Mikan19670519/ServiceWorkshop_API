using ServiceWorkshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceWorkshopAPI.Data.Contracts
{
	public interface ICustomerService
	{
		Task<List<CustomerModel>> GetCustomerDetailsAsync();
		Task<CustomerModel> GetCustomerDetailsByIdAsync(CustomerModel model);
		Task<CustomerModel> UpdateCustomerDetailsAsync(CustomerModel model);
		Task<CustomerModel> AddCustomerAsync(CustomerModel model);
		Task<bool> RemoveCustomerAsync(Guid id);
		Task<List<CustomerModel>> GetFilteredByCustomersAsync(string customer);
	}
}
