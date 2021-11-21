using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ICrimeSuburbRepository
    {
        public Task<IEnumerable<CrimeSuburbDTO>> GetAllCrimeSuburbs();
        public Task<IEnumerable<CrimeSuburbDTO>> GetCrimeSuburbByCityId(int cityId);

    }
}
