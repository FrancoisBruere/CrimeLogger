using AutoMapper;
using Business.Repository.IRepository;
using CrimeLogger.Shared;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeDetailRepository : ICrimeDetailRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CrimeDetailRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CrimeDetailDTO> CreateCrime(CrimeDetailDTO crimeDetailDTO)
        {
            CrimeDetail crimeDetail = _mapper.Map<CrimeDetailDTO, CrimeDetail>(crimeDetailDTO);
            crimeDetail.CreatedBy = "Developer";
            crimeDetail.CreatedDate = DateTime.Now;

            var addedCrimeDetail = await _db.CrimeDetails.AddAsync(crimeDetail);

            await _db.SaveChangesAsync();

            return _mapper.Map<CrimeDetail, CrimeDetailDTO>(addedCrimeDetail.Entity);
        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetAllCrimes()
        {
            IEnumerable<CrimeDetailDTO> crimeDetailDTOs =
                   _mapper.Map<IEnumerable<CrimeDetail>, IEnumerable<CrimeDetailDTO>>(_db.CrimeDetails);

            return crimeDetailDTOs;
        }

        public async Task<CrimeDetailDTO> GetCrime(int crimeId)
        {
            CrimeDetailDTO crimeDetail = _mapper.Map<CrimeDetail, CrimeDetailDTO>(
                    await _db.CrimeDetails.FirstOrDefaultAsync(x => x.Id == crimeId));
            return crimeDetail;
        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetCrimeByType(int typeId)
        {
            return _mapper.Map<IEnumerable<CrimeDetail>, IEnumerable<CrimeDetailDTO>>(
               await _db.CrimeDetails.Where(x => x.CrimeType_Id == typeId).ToListAsync());
        }
    }
}
