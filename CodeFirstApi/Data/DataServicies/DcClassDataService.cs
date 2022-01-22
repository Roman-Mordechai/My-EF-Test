using AutoMapper;
using CodeFirstApi.Domain.DataServices;
using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Data.DataServicies
{
    public class DcClassDataService : IDcClassDataService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DcClassDataService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDcClassDto> AddDcClass(AddDcClassDto dcClassDto)
        {
            var dcFrame = await _context.DcFrames
                .Where(m => m.Id == dcClassDto.DcFrameId)
                .Include(s => s.DcClasses)
                .FirstOrDefaultAsync();
            DcClassEntity dcClass = _mapper.Map<DcClassEntity>(dcClassDto);
            dcFrame.DcClasses.Add(dcClass);
            _context.DcFrames.Update(dcFrame);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcClassById(dcClass.Id);
            return _mapper.Map<GetDcClassDto>(dataRsp);
        }
        public async Task<GetDcClassDto> GetDcClassById(int id)
        {
            var dataRsp = await _context.DcClasses.Where(_ => _.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcClassDto>(dataRsp);
        }
        public async Task<GetDcClassDto> GetDcClassById(int id, int frameId)
        {
            var dataRsp = await _context.DcClasses.Where(_ => _.Id == id && _.DcFrame.Id == frameId ).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcClassDto>(dataRsp);
        }
        public async Task<List<GetDcClassDto>> GetDcClassesByFrameId(int frameId)
        {
            var dataRsp = await _context.DcClasses.Where(_ => _.DcFrame.Id == frameId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetDcClassDto>>(dataRsp);
        }
        public async Task<List<GetDcClassDto>> GetDcClassesByFrameCode(int frameCode)
        {
            var dataRsp = await _context.DcClasses.Where(_ => _.DcFrame.FrameCode == frameCode).AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetDcClassDto>>(dataRsp);
        }
        public async Task<GetDcClassDto> UpdateDcClass(UpdateDcClassDto dcClassDto)
        {
            DcClassEntity dcClass = _mapper.Map<DcClassEntity>(dcClassDto);
            _context.DcClasses.Update(dcClass);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcClassById(dcClassDto.Id);
            return _mapper.Map<GetDcClassDto>(dataRsp);

        }
        public async Task<GetDcClassDto> DeleteDcClass(GetDcClassDto dcClassDto)
        {
            DcClassEntity dcClass = _mapper.Map<DcClassEntity>(dcClassDto);
            _context.DcClasses.Remove(dcClass);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcClassById(dcClassDto.Id);
            return _mapper.Map<GetDcClassDto>(dataRsp);
        }

    }
}
