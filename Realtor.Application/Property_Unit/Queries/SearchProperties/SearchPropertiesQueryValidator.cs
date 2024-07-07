using FluentValidation;
using Realtor.Application.Authentication.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Property_Unit.Queries.SearchProperties
{

    public class SearchPropertiesQueryValidator : AbstractValidator<SearchPropertiesQuery>
    {
        public SearchPropertiesQueryValidator()
        {
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
