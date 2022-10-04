using API.Helpers.Utilities;

namespace crawler_api._Services.Interfaces
{
    public interface IService
    {
        Task<OperationResult> UploadExcel(IFormFile file);
    }
}