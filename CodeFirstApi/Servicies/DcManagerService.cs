﻿using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcManagerService : IDcManagerService
    {
        private readonly IDcManagerDataService _dcManagerDataService;

        public DcManagerService(IDcManagerDataService dcManagerDataService)
        {
            _dcManagerDataService = dcManagerDataService;
        }

        public async Task<ServiceResponse<List<GetDcManagerDto>>> AddManager(AddDcManagerDto addDcManager)
        {
            var serviceResponse = new ServiceResponse<List<GetDcManagerDto>>();

            try
            {
                return await _dcManagerDataService.AddManager(addDcManager);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "addDcManager service failed! " + ex.Message;
                return serviceResponse;
            }

        }

        public async Task<ServiceResponse<List<GetDcManagerDto>>> GetAllManagers()
        {
            var serviceResponse = new ServiceResponse<List<GetDcManagerDto>>();

            try
            {
                return await _dcManagerDataService.GetAllManagers();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetAllManagers service failed! " + ex.Message;
                return serviceResponse;
            }
        }
    }
}
