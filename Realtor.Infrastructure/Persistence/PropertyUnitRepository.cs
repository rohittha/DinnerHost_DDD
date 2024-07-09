
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Realtor.Application.Services;
using Realtor.Domain.Entities;
using Realtor.Infrastructure.Data;

namespace Realtor.Infrastructure.Persistence
{
    public class PropertyUnitRepository : GenericRepository<PropertyUnit>, IPropertyUnitRepository
    {
        public PropertyUnitRepository(AppDbContext context) : base(context)
        {
        }

    }
}
