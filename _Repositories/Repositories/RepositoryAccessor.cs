using API._Repositories.Interfaces;
using ImportDbApi._Repositories.Interfaces;
using ImportDbApi._Repositories.Repositories;
using ImportDbApi.Data;

namespace API._Repositories.Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private readonly DataContext _context;

        public RepositoryAccessor(DataContext context)
        {
            _context = context;
            Ward = new WardRepository(_context);
            District = new DistrictRepository(_context);
            Province = new ProvinceRepository(_context);
        }

        public IWardRepository Ward { get; private set; }

        public IDistrictRepository District { get; private set; }

        public IProvinceRepository Province { get; private set; }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}