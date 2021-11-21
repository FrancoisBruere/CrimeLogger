using Business.Repository.IRepository;
using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeTypeRepository : ICrimeTypeRepository
    {
        public Task<CrimeTypeDTO> CreateCrimeType(CrimeTypeDTO crimeTypeDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrimeTypeDTO>> GetAllCrimeTypes()
        {
            throw new NotImplementedException();
        }

        public Task<CrimeTypeDTO> GetCrimeType(int typeId)
        {
            throw new NotImplementedException();
        }
    }
}
