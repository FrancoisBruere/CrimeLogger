using Business.Repository.IRepository;
using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CrimeSuburbRepository : ICrimeSuburbRepository
    {
        public Task<IEnumerable<CrimeSuburbDTO>> GetAllCrimeSuburbs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrimeSuburbDTO>> GetCrimeSuburbByCityId(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
