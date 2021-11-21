using AutoMapper;
using Business.Repository.IRepository;
using CrimeLogger.Shared;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    
    public class CrimeProvinceRepository : ICrimeProvinceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CrimeProvinceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces()
        {
            IEnumerable<CrimeProvinceDTO> crimeProvinceDTOs =
                _mapper.Map<IEnumerable<CrimeProvince>, IEnumerable<CrimeProvinceDTO>>(_db.CrimeProvinces);
            return crimeProvinceDTOs;
        }
    }
}
