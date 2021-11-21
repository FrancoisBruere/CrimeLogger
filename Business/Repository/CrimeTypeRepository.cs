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
    public class CrimeTypeRepository : ICrimeTypeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CrimeTypeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CrimeTypeDTO> CreateCrimeType(CrimeTypeDTO crimeTypeDTO)
        {
            CrimeType crimeType = _mapper.Map<CrimeTypeDTO, CrimeType>(crimeTypeDTO);


            var addedCrimeType = await _db.CrimeTypes.AddAsync(crimeType);

            await _db.SaveChangesAsync();

            return _mapper.Map<CrimeType, CrimeTypeDTO>(addedCrimeType.Entity);
        }

        public async Task<IEnumerable<CrimeTypeDTO>> GetAllCrimeTypes()
        {
            IEnumerable<CrimeTypeDTO> crimeTypeDTOs =
                   _mapper.Map<IEnumerable<CrimeType>, IEnumerable<CrimeTypeDTO>>(_db.CrimeTypes);

            return crimeTypeDTOs;
        }

        public async Task<CrimeTypeDTO> GetCrimeType(int typeId)
        {
            if (typeId == 0)
            {
                throw new NullReferenceException();
            }

            CrimeTypeDTO crimeTypeDetail = _mapper.Map<CrimeType, CrimeTypeDTO>(
                   await _db.CrimeTypes.FirstOrDefaultAsync(x => x.CrimeId == typeId));

            if (crimeTypeDetail == null)
            {

                return null;
            }

            return crimeTypeDetail;
        }
    }
}
