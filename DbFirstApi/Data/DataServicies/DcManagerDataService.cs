using DbFirstApi.Domain.DataServices;
using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirstApi.Data.DataServicies
{
    public class DcManagerDataService : IDcManagerDataService
    {
        private readonly DataContext _context;
        private readonly ILogger<DcManagerDataService> _logger;

        public DcManagerDataService(
            DataContext context,
            ILogger<DcManagerDataService> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse> AddDcManager(DcManagerEntity dcManager)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcManagers.Add(dcManager);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"UpdateDcManager data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<DcManagerEntity>>> GetAllDcManagers()
        {
            var serviceResponse = new ServiceResponse<List<DcManagerEntity>>();
            try
            {
                serviceResponse.Data = await _context.DcManagers.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetAllDcManagers data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcManagerEntity>> GetDcManagerById(int id)
        {
            var serviceResponse = new ServiceResponse<DcManagerEntity>();
            try
            {
                serviceResponse.Data = await _context.DcManagers.Where(m => m.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcManagerById data service failed! {ex.Message}";
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<DcManagerEntity>> GetDcManagerById(int id, int managerId)
        {
            var serviceResponse = new ServiceResponse<DcManagerEntity>();
            try
            {
                serviceResponse.Data = await _context.DcManagers
                    .Where(m => m.Id == id && m.ManagerId == managerId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcManagerById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcManagerEntity>> GetDcManagerByManagerId(int id)
        {
            var serviceResponse = new ServiceResponse<DcManagerEntity>();
            try
            {
                serviceResponse.Data = await _context.DcManagers
                    .Where(m => m.ManagerId == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcManagerByManagerId data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcManager(DcManagerEntity dcManager)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcManagers.Update(dcManager);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"UpdateDcManager data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcManager(DcManagerEntity dcManager)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcManagers.Remove(dcManager);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"DeleteDcManager data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
    }
}
