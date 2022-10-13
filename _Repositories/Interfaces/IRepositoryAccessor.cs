using ImportDbApi._Repositories.Interfaces;

namespace API._Repositories.Interfaces
{
    public interface IRepositoryAccessor
    {
        IWardRepository Ward { get; }
        IDistrictRepository District { get; }
        IProvinceRepository Province { get; }
        Task<bool> Save();
    }
}