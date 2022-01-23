using AutoMapper;
using CodeFirstApi.Domain.DataServices;
using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Data.DataServicies
{
    public class DcFrameDataService : IDcFrameDataService
    {
        private readonly DataContext _context;
        private readonly ILogger<DcFrameDataService> _logger;

        public DcFrameDataService(
            DataContext context, 
            ILogger<DcFrameDataService> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse> AddDcFrame(DcFrameEntity dcFrame)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcFrames.Add(dcFrame);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"AddDcFrame data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<DcFrameEntity>>> GetAllDcFrames()
        {
            var serviceResponse = new ServiceResponse<List<DcFrameEntity>>();
            try
            {
                serviceResponse.Data = await _context.DcFrames
                .Include(c => c.DcClasses)
                .Include(c => c.DcManager)
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetAllDcFrames data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcFrameEntity>> GetDcFrameById(int id)
        {
            var serviceResponse = new ServiceResponse<DcFrameEntity>();
            try
            {
                serviceResponse.Data = await _context.DcFrames
                .Where(_ => _.Id == id)
                .Include(c => c.DcClasses)
                .Include(c => c.DcManager)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcFrameById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcFrameEntity>> GetDcFrameById(int id, int frameCode)
        {
            var serviceResponse = new ServiceResponse<DcFrameEntity>();
            try
            {
                serviceResponse.Data = await _context.DcFrames
                .Where(_ => _.Id == id && _.FrameCode == frameCode)
                .Include(c => c.DcClasses)
                .Include(c => c.DcManager)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcFrameById data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<DcFrameEntity>> GetDcFrameByFrameCode(int frameCode)
        {
            var serviceResponse = new ServiceResponse<DcFrameEntity>();
            try
            {
                serviceResponse.Data = await _context.DcFrames
                .Where(_ => _.FrameCode == frameCode)
                .Include(c => c.DcClasses)
                .Include(c => c.DcManager)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"GetDcFrameByFrameCode data service failed! {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcFrame(DcFrameEntity dcFrame)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcFrames.Update(dcFrame);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"UpdateDcFrame data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcFrame(DcFrameEntity dcFrame)
        {
            var serviceResponse = new ServiceResponse();
            try
            {
                _context.DcFrames.Remove(dcFrame);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                serviceResponse.Success = false;
                serviceResponse.Message = $"DeleteDcFrame data service failed! {ex.Message} : {ex.InnerException.Message}";
            }
            return serviceResponse;
        }
    }
}
