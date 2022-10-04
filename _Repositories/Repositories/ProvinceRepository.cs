using API._Repositories.Repositories;
using crawler_api._Repositories.Interfaces;
using crawler_api.Data;
using crawler_api.Models;

namespace crawler_api._Repositories.Repositories
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DataContext context) : base(context)
        {
        }
    }
}