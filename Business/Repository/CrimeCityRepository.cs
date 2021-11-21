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
    public class CrimeCityRepository : ICrimeCityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CrimeCityRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CrimeCityDTO>> GetAllCrimeCities()
        {
            IEnumerable<CrimeCityDTO> crimeCityDTOs =
                   _mapper.Map<IEnumerable<CrimeCity>, IEnumerable<CrimeCityDTO>>(_db.CrimeCities);

            return crimeCityDTOs;
        }

        public async Task<IEnumerable<CrimeCityDTO>> GetCrimeCitiesByProvinceId(int provinceId)
        {
            return _mapper.Map<IEnumerable<CrimeCity>, IEnumerable<CrimeCityDTO>>(
               await _db.CrimeCities.Where(x => x.ProvinceId == provinceId).ToListAsync());
        }
    }
}
