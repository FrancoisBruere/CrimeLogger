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
    public class CrimeSuburbRepository : ICrimeSuburbRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CrimeSuburbRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CrimeSuburbDTO>> GetAllCrimeSuburbs()
        {
            IEnumerable<CrimeSuburbDTO> crimeSuburbDTOs =
                   _mapper.Map<IEnumerable<CrimeSuburb>, IEnumerable<CrimeSuburbDTO>>(_db.CrimeSuburbs);

            return crimeSuburbDTOs;
        }

        public async Task<IEnumerable<CrimeSuburbDTO>> GetCrimeSuburbByCityId(int cityId)
        {
            return _mapper.Map<IEnumerable<CrimeSuburb>, IEnumerable<CrimeSuburbDTO>>(
                await _db.CrimeSuburbs.Where(x => x.CityId == cityId).ToListAsync());
        }
    }
}
