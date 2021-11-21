using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface ICrimeProvinceCitySuburbService
    {
        public Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces();
    }
}
