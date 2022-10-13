using API._Repositories.Repositories;
using ImportDbApi._Repositories.Interfaces;
using ImportDbApi.Data;
using ImportDbApi.Models;

namespace ImportDbApi._Repositories.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(DataContext context) : base(context)
        {
        }
    }
}