using Mapster;
using Realtor.Application.Property_Unit.Commands.Create;
using Realtor.Application.Property_Unit.Common;
using Realtor.Application.Property_Unit.Queries.SearchProperties;
using Realtor.Domain.Entities;

namespace Realtor.Application.Common.Mapping
{
    public class PropertyUnitMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePropertyCommand, PropertyUnit>();
            config.NewConfig<PropertyUnit, CreatePropertyResult>();
            config.NewConfig<PropertyUnit, SearchPropertiesResult>();
        }
    }
}
