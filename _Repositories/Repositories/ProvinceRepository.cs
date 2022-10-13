using API._Repositories.Repositories;
using ImportDbApi._Repositories.Interfaces;
using ImportDbApi.Data;
using ImportDbApi.Models;

namespace ImportDbApi._Repositories.Repositories
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DataContext context) : base(context)
        {
        }
    }
}