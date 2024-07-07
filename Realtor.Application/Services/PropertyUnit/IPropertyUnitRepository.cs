
using Realtor.Domain.Entities;

namespace Realtor.Application.Services
{
    public interface IPropertyUnitRepository
    {
        public Task<List<PropertyUnit>> GetPropertiesAsync();
        public Task<PropertyUnit> CreatePropertyAsync(PropertyUnit property);
        public Task<PropertyUnit?> UpdatePropertyAsync(int Id, PropertyUnit property);
        public Task<PropertyUnit?> GetPropertyAsync(int id);
    }
}
