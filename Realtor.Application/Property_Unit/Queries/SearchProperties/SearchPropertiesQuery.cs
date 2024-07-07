using ErrorOr;
using MediatR;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Property_Unit.Common;

namespace Realtor.Application.Property_Unit.Queries.SearchProperties
{
    public record SearchPropertiesQuery
    (
        string? Description
        , string? Type
        , string? Address
        , string? Address2

        , string? City
        , string? Region
        , string? PostalCode
        , string? Country
        , string? Phone
    ) : IRequest<ErrorOr<List<SearchPropertiesResult>>>;
    //) : IRequest<ErrorOr<SearchPropertiesResult>>;
}
