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
	public class CustomerService : ICustomerService
	{
		private readonly ServiceWorkshopDbContext _dbContext;
		private readonly IMapper _mapper;
		protected readonly ILogger<CustomerService> _logger;

		public CustomerService(ServiceWorkshopDbContext dbContext, IMapper mapper, ILogger<CustomerService> logger)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<CustomerModel> AddCustomerAsync(CustomerModel model)
		{
			try
			{
				var entityObject = await _dbContext.Customers
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.CustomerID == model.CustomerId);

				if (entityObject == null)
				{
					var customer = new CustomerEntity();
					customer.ContactNumber = model.ContactNumber;
					customer.DateAdded = DateTime.Now;
					customer.Name = model.Name;
					customer.Surname = model.Surname;

					_dbContext.Customers.Add(customer);

					await _dbContext.SaveChangesAsync();

					Guid max = _dbContext.Customers.Max(p => p.CustomerID);
					model.CustomerId = max;
				}
				else
				{
					await UpdateCustomerDetailsAsync(model);
				}

				return model;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<CustomerModel> UpdateCustomerDetailsAsync(CustomerModel model)
		{
			try
			{
				var entityObject = await _dbContext.Customers
					.AsQueryable()
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.CustomerID == model.CustomerId);

				if (entityObject != null)
				{
					entityObject.DateUpdated = DateTime.Now;
					entityObject.ContactNumber = model.ContactNumber;
					entityObject.Name = model.Name;
					entityObject.Surname = model.Surname;

					_dbContext.Customers.Update(entityObject);

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

		public async Task<List<CustomerModel>> GetCustomerDetailsAsync()
		{
			try
			{
				List<CustomerModel> customers = await _dbContext.Customers
								.AsQueryable()
								.AsNoTracking()
								.Select(x => new CustomerModel
								{
									ContactNumber = x.ContactNumber,
									Name = x.Name,
									Surname = x.Surname,
									CustomerId = x.CustomerID,
									DateAdded = x.DateAdded
								}).ToListAsync();

				return customers;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<CustomerModel> GetCustomerDetailsByIdAsync(CustomerModel model)
		{
			try
			{
				CustomerModel customer = await _dbContext.Customers
								.AsQueryable()
								.AsNoTracking()
								.Where(p => p.CustomerID == model.CustomerId)
								.Select(x => new CustomerModel
								{
									Name = x.Name,
									Surname = x.Surname,
									ContactNumber = x.ContactNumber,
									CustomerId = x.CustomerID,
									DateAdded = x.DateAdded
								}).FirstOrDefaultAsync();

				return customer;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}

		public async Task<bool> RemoveCustomerAsync(Guid id)
		{
			try
			{
				var entityObject = await _dbContext.Customers
								.AsQueryable()
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.CustomerID == id);

				if (entityObject != null)
				{
					_dbContext.Customers.Remove(entityObject);
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

		public async Task<List<CustomerModel>> GetFilteredByCustomersAsync(string customer)
		{
			try
			{
				List<CustomerModel> customers = await _dbContext.Customers
					.AsQueryable()
					.AsNoTracking()
					.Where(x => x.Name.Contains(customer.ToLower().Trim()))
					.Select(x => new CustomerModel
					{
						CustomerId = x.CustomerID,
						Name = x.Name,
						Surname = x.Surname,
						ContactNumber = x.ContactNumber
					}).ToListAsync();

				return customers;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return null;
			}
		}
	}
}