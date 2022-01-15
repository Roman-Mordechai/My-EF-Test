using AutoMapper;
using CodeFirstApi.Data;
using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<GetDcManagerDto> AddDcManager(AddDcManagerDto dcManagerDto)
        {
            DcManagerEntity dcManager = _mapper.Map<DcManagerEntity>(dcManagerDto);
            _context.DcManagers.Add(dcManager);
            await _context.SaveChangesAsync();
            var dataRsp = await _context.DcManagers.Where(m => m.ManagerId == dcManagerDto.ManagerId).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }

        public async Task<List<GetDcManagerDto>> GetAllDcManagers()
        {
            var dataRsp = await _context.DcManagers.AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetDcManagerDto>>(dataRsp);
        }

        public async Task<GetDcManagerDto> GetDcManagerById(int id)
        {
            var dataRsp = await _context.DcManagers.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }

        public async Task<GetDcManagerDto> GetDcManagerById(int id, int managerId)
        {
            var dataRsp = await _context.DcManagers.Where(m => m.Id == id && m.ManagerId == managerId).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }

        public async Task<GetDcManagerDto> GetDcManagerByManagerId(int id)
        {
            var dataRsp = await _context.DcManagers.Where(m => m.ManagerId == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }

        public async Task<GetDcManagerDto> UpdateDcManager(GetDcManagerDto dcManagerDto)
        {
            DcManagerEntity dcManager = _mapper.Map<DcManagerEntity>(dcManagerDto);
            _context.DcManagers.Update(dcManager);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcManagerById(dcManagerDto.Id);
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }

        public async Task<GetDcManagerDto> DeleteDcManager(GetDcManagerDto dcManagerDto)
        {
            DcManagerEntity dcManager = _mapper.Map<DcManagerEntity>(dcManagerDto);
            _context.DcManagers.Remove(dcManager);
            await _context.SaveChangesAsync();
            var dataRsp = await GetDcManagerById(dcManagerDto.Id);
            return _mapper.Map<GetDcManagerDto>(dataRsp);
        }


    }
}
