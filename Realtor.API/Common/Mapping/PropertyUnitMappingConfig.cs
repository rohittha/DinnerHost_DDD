using Mapster;
using Realtor.Application.Property_Unit.Common;
using Realtor.Application.Property_Unit.Queries.SearchProperties;
using Realtor.Contracts.PropertyUnit;

namespace Realtor.API.Common.Mapping
{
    public class PropertyUnitMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SearchPropertiesRequest, SearchPropertiesQuery>();
            config.NewConfig<SearchPropertiesResult, SearchPropertyResponse>();
        }
    }
}
