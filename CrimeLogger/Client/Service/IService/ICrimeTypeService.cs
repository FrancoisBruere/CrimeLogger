using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface ICrimeTypeService
    {
        public Task<IEnumerable<CrimeTypeDTO>> GetAllCrimeTypes();

    }
}
