using AutoMapper;
using CodeFirstApi.Data;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcManager;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcManagerDataService : IDcManagerDataService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DcManagerDataService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDcManagerDto>>> AddDcManager(AddDcManagerDto addDcManager)
        {
            var serviceResponse = new ServiceResponse<List<GetDcManagerDto>>();
            DcManagerEntity newDcManager = _mapper.Map<DcManagerEntity>(addDcManager);
            _context.DcManagers.Add(newDcManager);
            await _context.SaveChangesAsync();

            var dataRsp = await _context.DcManagers
                .ToListAsync();

            serviceResponse.Data = _mapper.Map<List<GetDcManagerDto>>(dataRsp);

            return serviceResponse;

        }
    }
}
