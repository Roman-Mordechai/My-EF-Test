using AutoMapper;
using CodeFirstApi.Data;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcFrame;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcFrameDataService : IDcFrameDataService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DcFrameDataService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDcFrameDto>>> AddFrame(AddDcFrameDto addDcFrame)
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();
            DcFrameEntity newDcFrame = _mapper.Map<DcFrameEntity>(addDcFrame);
            
            newDcFrame.DcManager = await _context.DcManagers.Where( m => m.ManagerId == addDcFrame.DcManagerId)
                .FirstOrDefaultAsync();

            _context.DcFrames.Add(newDcFrame);
            await _context.SaveChangesAsync();

            var dataRsp = await _context.DcFrames
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .ToListAsync();

            serviceResponse.Data = _mapper.Map<List<GetDcFrameDto>>(dataRsp);

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetDcFrameDto>>> GetAllFrames()
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();
            var dataRsp = await _context.DcFrames
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .ToListAsync();

            serviceResponse.Data = _mapper.Map<List<GetDcFrameDto>>(dataRsp);

            return serviceResponse;
        }
    }
}
