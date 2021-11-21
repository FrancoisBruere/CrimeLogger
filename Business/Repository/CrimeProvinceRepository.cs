using Business.Repository.IRepository;
using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeProvinceRepository : ICrimeProvinceRepository
    {
        public Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces()
        {
            throw new NotImplementedException();
        }
    }
}
