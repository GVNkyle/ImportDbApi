using API._Repositories.Repositories;
using ImportDbApi._Repositories.Interfaces;
using ImportDbApi.Data;
using ImportDbApi.Models;

namespace ImportDbApi._Repositories.Repositories
{
    public class WardRepository : Repository<Ward>, IWardRepository
    {
        public WardRepository(DataContext context) : base(context)
        {
        }
    }
}