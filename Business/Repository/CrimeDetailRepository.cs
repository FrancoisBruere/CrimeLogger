using Business.Repository.IRepository;
using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeDetailRepository : ICrimeDetailRepository
    {
        public Task<CrimeDetailDTO> CreateCrime(CrimeDetailDTO crimeDetailDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrimeDetailDTO>> GetAllCrimes()
        {
            throw new NotImplementedException();
        }

        public Task<CrimeDetailDTO> GetCrime(int crimeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrimeDetailDTO>> GetCrimeByType(int typeId)
        {
            throw new NotImplementedException();
        }
    }
}
