namespace Realtor.Contracts.PropertyUnit
{
    public record SearchPropertiesRequest
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
    );
}
