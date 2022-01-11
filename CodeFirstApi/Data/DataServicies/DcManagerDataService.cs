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

        public async Task<ServiceResponse<List<DcManagerEntity>>> AddDcManager(AddDcManagerDto addDcManager)
        {
            var serviceResponse = new ServiceResponse<List<DcManagerEntity>>();
            DcManagerEntity newDcManager = _mapper.Map<DcManagerEntity>(addDcManager);
            _context.DcManagers.Add(newDcManager);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.DcManagers
                .ToListAsync();
            return serviceResponse;

        }
    }
}
