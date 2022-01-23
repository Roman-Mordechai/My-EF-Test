using AutoMapper;
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
    public class DcClassDataService : IDcClassDataService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<DcClassDataService> _logger;

        public DcClassDataService(
            DataContext context,
            ILogger<DcClassDataService> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddDcClass(DcClassEntity dcClass)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcClasses.Update(dcClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"AddDcClass data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id)
        {
            var serviceResponse = new ServiceResponse<DcClassEntity>();
            try
            {
                serviceResponse.Data = await _context
                    .DcClasses.Where(_ => _.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcClassById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id, int frameId)
        {
            var serviceResponse = new ServiceResponse<DcClassEntity>();
            try
            {
                serviceResponse.Data = await _context.DcClasses
                    .Where(_ => _.Id == id && _.DcFrameId == frameId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcClassById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<DcClassEntity>>> GetDcClassesByFrameId(int frameId)
        {
            var serviceResponse = new ServiceResponse<List<DcClassEntity>>();
            try
            {
                serviceResponse.Data = await _context.DcClasses
                    .Where(_ => _.DcFrameId == frameId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcClassById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcClass(DcClassEntity dcClass)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcClasses.Update(dcClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"AddDcClass data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcClass(DcClassEntity dcClass)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcClasses.Remove(dcClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"AddDcClass data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }

    }
}
