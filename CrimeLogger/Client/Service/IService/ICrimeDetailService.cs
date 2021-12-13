using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface ICrimeDetailService
    {
        public Task<IEnumerable<CrimeDetailDTO>> GetAllCrimeDetails();
        public Task<HttpResponseMessage> CreateCrime(CrimeDetailDTO crimeDetailDTO);

        public Task<IEnumerable<CrimeDetailDTO>> GetCrimeDetailsByTypeId(int typeId);
    }
}
