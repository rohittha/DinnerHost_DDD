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
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Realtor.Application.Property_Unit.Queries.SearchProperties
{
    //public class SearchPropertiesQueryHandler : IRequestHandler<SearchPropertiesQuery, ErrorOr<List<SearchPropertiesResult>>>
    public class SearchPropertiesQueryHandler : IRequestHandler<SearchPropertiesQuery, ErrorOr<SearchPropertiesResult>>
    {
        private readonly IPropertyUnitRepository _propertyRepository;
        public SearchPropertiesQueryHandler(IPropertyUnitRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        //public async Task<ErrorOr<List<SearchPropertiesResult>>> Handle(SearchPropertiesQuery request, CancellationToken cancellationToken)
        public async Task<ErrorOr<SearchPropertiesResult>> Handle(SearchPropertiesQuery request, CancellationToken cancellationToken)
        {
            //1.Check if user exists
            //if (_propertyRepository.GetPropertiesAsync(request.Email) is not User user)     // TODO check what does this mean: is not User user
            //{
            //    //throw new Exception("User with given email does not exist!");
            //    return Errors.Authentication.InvalidCredentials;
            //}

            //var propretyList = await _propertyRepository.GetPropertiesAsync();

            if (await _propertyRepository.GetPropertiesAsync() is not List<PropertyUnit> propertyList)     // TODO check what does this mean: is not User user
            {
                //throw new Exception("User with given email does not exist!");
                return Errors.PropertyUnit.NoPropertiesFound;
            }

            ////2. Check if password correct
            //if (user.Password != request.Password)
            //{
            //    //throw new Exception("Invalid password!");
            //    return Errors.Authentication.InvalidCredentials;
            //}
            //3. Create JWT token for the new user
            //var token = _jwtTokenGenerator.GenerateToken(user);

            //List<SearchPropertiesResult> results = new List<SearchPropertiesResult>();
            SearchPropertiesResult results = new SearchPropertiesResult(1, "2BHK Test", "R", "123 ABC Road", "Unit 99", "London", "Ont", "NNN111", "Canada", "9876543210");



            return results;
        }

    }
}
