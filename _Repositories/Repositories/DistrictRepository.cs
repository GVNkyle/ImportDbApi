using API._Repositories.Repositories;
using crawler_api._Repositories.Interfaces;
using crawler_api.Data;
using crawler_api.Models;

namespace crawler_api._Repositories.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(DataContext context) : base(context)
        {
        }
    }
}