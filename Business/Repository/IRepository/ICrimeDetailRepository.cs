using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ICrimeDetailRepository
    {
        public Task<CrimeDetailDTO> CreateCrime(CrimeDetailDTO crimeDetailDTO);
        public Task<CrimeDetailDTO> GetCrime(int crimeId);
        public Task<IEnumerable<CrimeDetailDTO>> GetCrimeByType(int typeId);
        public Task<IEnumerable<CrimeDetailDTO>> GetAllCrimes();

    }
}
