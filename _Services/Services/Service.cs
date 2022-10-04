using API._Repositories.Interfaces;
using API.Helpers.Utilities;
using Aspose.Cells;
using crawler_api._Services.Interfaces;
using crawler_api.Dto;
using crawler_api.Models;

namespace crawler_api._Services.Services
{
    public class Service : IService
    {
        private readonly IRepositoryAccessor _repository;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public Service(IRepositoryAccessor repository, IWebHostEnvironment webhostEnvironment)
        {
            _repository = repository;
            _webhostEnvironment = webhostEnvironment;
        }

        public async Task<OperationResult> UploadExcel(IFormFile file)
        {
            if (file == null)
                return new OperationResult(false, "File not found.");

            var uploadFile = $"UploadFile";
            var uploadPath = @"uploaded\excels";
            var fileName = await new FunctionUtility().UploadAsync(file, uploadPath, uploadFile);
            var filePath = Path.Combine(_webhostEnvironment.WebRootPath, uploadPath, fileName);

            // Đọc file
            var designer = new WorkbookDesigner();
            designer.Workbook = new Workbook(filePath);
            var ws = designer.Workbook.Worksheets[0];
            int rows = ws.Cells.MaxDataRow;
            List<Model> listData = new List<Model>();
            if (rows < 1)
                return new OperationResult(false, "An empty excel file", "Error");

            for (var i = 1; i <= rows; i++)
            {
                Model model = new Model();
                model.Ward_code = ws.Cells[i, 0].StringValue?.Trim();
                model.Ward_name = ws.Cells[i, 1].StringValue?.Trim();
                model.District_code = ws.Cells[i, 4].StringValue?.Trim();
                model.District_name = ws.Cells[i, 5].StringValue?.Trim();
                model.Province_code = ws.Cells[i, 6].StringValue?.Trim();
                model.Province_name = ws.Cells[i, 7].StringValue?.Trim();
                listData.Add(model);
            }

            var listProvinces = listData.GroupBy(x => x.Province_code).Select(x => new Province
            {
                Code = x.Key,
                Name = x.FirstOrDefault().Province_name,
            }).ToList();
            _repository.Province.UpdateMultiple(listProvinces);

            List<District> listDistrict = new List<District>();

            foreach (var item in listProvinces)
            {
                var temp = listData.Where(x => x.Province_code == item.Code)
                                    .GroupBy(x => x.District_code).Select(x => new District
                                    {
                                        Code = x.Key,
                                        Name = x.FirstOrDefault().District_name,
                                        ProvinceCode = x.FirstOrDefault().Province_code
                                    }).ToList();
                listDistrict.AddRange(temp);
            }
            _repository.District.UpdateMultiple(listDistrict);
            List<Ward> listWard = new List<Ward>();
            foreach (var item in listData)
            {
                var ward = new Ward
                {
                    Code = item.Ward_code,
                    Name = item.Ward_name,
                    DistrictCode = item.District_code
                };
                listWard.Add(ward);
            }

            _repository.Ward.UpdateMultiple(listWard);
            if (await _repository.Save())
                return new OperationResult(true);
            else return new OperationResult(false);
        }
    }
}