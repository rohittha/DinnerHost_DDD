using Azure.Core;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Queries.Login;
using Realtor.Application.Property_Unit.Commands.Create;
using Realtor.Application.Property_Unit.Common;
using Realtor.Application.Property_Unit.Queries.SearchProperties;
using Realtor.Contracts.Authentication;
using Realtor.Contracts.PropertyUnit;

namespace Realtor.API.Controllers
{
    [Route("properties")]
    public class PropertiesController : ApiController
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        public PropertiesController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [Route("all")]
        [HttpPost]
        public async Task<IActionResult> SearchProperties(SearchPropertiesRequest request)
        {
            var query = _mapper.Map<SearchPropertiesQuery>(request);
            //var query1 = _mapper.Map<LoginQuery>(request);
            var searchPropertiesResult = await _mediatr.Send(query);

            // Map list of Result
            var result = searchPropertiesResult.Match(result => Ok(_mapper.Map<List<SearchPropertyResponse>>(result)),
                errors => Problem(errors));
            return result;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProperty(CreatePropertyRequest request)
        {
            var command = _mapper.Map<CreatePropertyCommand>(request);
            ErrorOr<CreatePropertyResult> result = await _mediatr.Send(command);

            return result.Match(createResult => Ok(_mapper.Map<CreatePropertyResponse>(createResult)),
                errors => Problem(errors));
        }
    }
}
