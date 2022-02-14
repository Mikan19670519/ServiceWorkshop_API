using AutoMapper;
using Serilog;
using ServiceWorkshopAPI.Data.DataContexts;

namespace ServiceWorkshopAPI.Services
{
    public class BaseService
    {
        protected readonly ServiceWorkshopDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseService(ServiceWorkshopDbContext dbContext, IMapper mapper, ILogger logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
