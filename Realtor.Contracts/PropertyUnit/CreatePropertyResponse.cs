namespace Realtor.Contracts.PropertyUnit
{
    public record CreatePropertyResponse
    (
         //int? Id ,             // User will not be passing ID for a new record
         string? Description ,
         string? Type ,
         string? Address ,
         string? Address2 ,
         string? City ,
         string? Region ,
         string? PostalCode ,
         string? Country ,
         string? Phone 
    );
}
