using Business.Repository.IRepository;
using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeCityRepository : ICrimeCityRepository
    {
        public Task<IEnumerable<CrimeCityDTO>> GetAllCrimeCities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrimeCityDTO>> GetCrimeCitiesByProvinceId(int provinceId)
        {
            throw new NotImplementedException();
        }
    }
}
