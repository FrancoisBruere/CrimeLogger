using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface ICrimeProvinceCitySuburbService
    {
        public Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces();

        public Task<IEnumerable<CrimeCityDTO>> GetCityDetailsByProvinceId(int provinceId);

        public Task<IEnumerable<CrimeSuburbDTO>> GetSuburbDetailsByCityId(int cityId);
    }
}
