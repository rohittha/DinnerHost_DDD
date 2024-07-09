
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Domain.Entities;

namespace Realtor.Application.Services
{
    public interface IPropertyUnitRepository : IGenericRepository<PropertyUnit>
    {
        //public Task<List<PropertyUnit>> GetPropertiesAsync();
        //public Task<PropertyUnit> CreatePropertyAsync(PropertyUnit property);
        //public Task<PropertyUnit?> GetPropertyAsync(int id);

        //public Task<PropertyUnit?> UpdatePropertyAsync(int Id, PropertyUnit property);

    }
}
