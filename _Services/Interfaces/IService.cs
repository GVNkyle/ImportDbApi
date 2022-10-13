using API.Helpers.Utilities;

namespace ImportDbApi._Services.Interfaces
{
    public interface IService
    {
        Task<OperationResult> UploadExcel(IFormFile file);
    }
}