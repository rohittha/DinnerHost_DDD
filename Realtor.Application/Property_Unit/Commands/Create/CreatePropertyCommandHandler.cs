using ErrorOr;
using MapsterMapper;
using MediatR;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Application.Property_Unit.Queries.SearchProperties;
using Realtor.Application.Services;
using Realtor.Domain.Entities;
using Realtor.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Mapster;

namespace Realtor.Application.Property_Unit.Commands.Create
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, ErrorOr<CreatePropertyResult>>
    {
        private readonly IMapper _mapper;
        IPropertyUnitRepository _propertyUnitRepository;
        public CreatePropertyCommandHandler(IPropertyUnitRepository propertyUnitRepository, IMapper mapper)
        {
            _propertyUnitRepository = propertyUnitRepository;
            _mapper = mapper;
        }
        public async Task<ErrorOr<CreatePropertyResult>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var propertyUnit = _mapper.Map<PropertyUnit>(request);
            // TODO Add error handling and validation        

            var result = await _propertyUnitRepository.CreatePropertyAsync(propertyUnit);
            var createPropertyResult = _mapper.Map<CreatePropertyResult>(result);
            return createPropertyResult;
        }
    }
}
