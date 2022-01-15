using AutoMapper;
using CodeFirstApi.Data;
using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
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

        public async Task<GetDcFrameDto> AddDcFrame(AddDcFrameDto dcFrameDto)
        {
            DcFrameEntity dcFrame = _mapper.Map<DcFrameEntity>(dcFrameDto);
            dcFrame.DcManager = await _context.DcManagers.Where( m => m.Id == dcFrameDto.DcManagerId)
                .FirstOrDefaultAsync();
            _context.DcFrames.Add(dcFrame);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcFrameByFrameCode(dcFrameDto.FrameCode);
            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }

        public async Task<List<GetDcFrameDto>> GetAllDcFrames()
        {
            var dataRsp = await _context.DcFrames
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<GetDcFrameDto>>(dataRsp);
        }

        public async Task<GetDcFrameDto> GetDcFrameById(int id)
        {
            var dataRsp = await _context.DcFrames
                .Where(_ => _.Id == id)
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }

        public async Task<GetDcFrameDto> GetDcFrameById(int id, int frameCode)
        {
            var dataRsp = await _context.DcFrames
                .Where(_ => _.Id == id && _.FrameCode == frameCode)
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }

        public async Task<GetDcFrameDto> GetDcFrameByFrameCode(int frameCode)
        {
            var dataRsp = await _context.DcFrames
                .Where(_ => _.FrameCode == frameCode)
                .Include(c => c.Classes)
                .Include(c => c.DcManager)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }

        public async Task<GetDcFrameDto> UpdateDcFrame(UpdateDcFrameDto dcFrameDto)
        {
            DcFrameEntity dcFrame = _mapper.Map<DcFrameEntity>(dcFrameDto);
            dcFrame.DcManager = await _context.DcManagers.Where(m => m.Id == dcFrameDto.DcManagerId)
                .FirstOrDefaultAsync();
            _context.DcFrames.Update(dcFrame);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcFrameById(dcFrameDto.Id);
            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }

        public async Task<GetDcFrameDto> DeleteDcFrame(GetDcFrameDto dcFrameDto)
        {
            DcFrameEntity dcFrame = _mapper.Map<DcFrameEntity>(dcFrameDto);
            _context.DcFrames.Remove(dcFrame);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcFrameById(dcFrameDto.Id);
            return _mapper.Map<GetDcFrameDto>(dataRsp);
        }
    }
}
