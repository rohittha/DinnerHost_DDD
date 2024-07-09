using ErrorOr;
using MediatR;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Authentication.Queries.Login;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Application.Property_Unit.Common;
using Realtor.Application.Services;
using Realtor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realtor.Domain.Common.Errors;
using MapsterMapper;
using Mapster;
using Realtor.Application.Common.Mapping;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Realtor.Application.Property_Unit.Queries.SearchProperties
{
    public class SearchPropertiesQueryHandler : IRequestHandler<SearchPropertiesQuery, ErrorOr<List<SearchPropertiesResult>>>
    {
        private readonly IMapper _mapper;
        private readonly IPropertyUnitRepository _propertyRepository;
        public SearchPropertiesQueryHandler(IMapper mapper, IPropertyUnitRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }

        public async Task<ErrorOr<List<SearchPropertiesResult>>> Handle(SearchPropertiesQuery request, CancellationToken cancellationToken)
        {
            var propertyList = await _propertyRepository.All();

            if (propertyList is not List<PropertyUnit>) // TODO check how this works
            {
                return Errors.PropertyUnit.NoPropertiesFound;
            }

            List<SearchPropertiesResult> resultList = TypeAdapter.Adapt<List<SearchPropertiesResult>>(propertyList);

            //HardCoded result list
            //SearchPropertiesResult results = new SearchPropertiesResult(1, "2BHK Test", "R", "123 ABC Road", "Unit 99", "London", "Ont", "NNN111", "Canada", "9876543210");

            return resultList;
        }
    }
}
