using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ICrimeTypeRepository
    {
        public Task<IEnumerable<CrimeTypeDTO>> GetAllCrimeTypes();

        public Task<CrimeTypeDTO> CreateCrimeType(CrimeTypeDTO crimeTypeDTO);

        public Task<CrimeTypeDTO> GetCrimeType(int typeId);
    }
}
