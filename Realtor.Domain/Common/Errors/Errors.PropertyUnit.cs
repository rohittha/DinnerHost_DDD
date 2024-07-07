using ErrorOr;

namespace Realtor.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class PropertyUnit
        {
            public static Error NoPropertiesFound
            {
                get
                {
                    return Error.Validation(
                        code: "Properties.NotFound",
                        description: "No Properties Found with Search Critertia");
                }
            }
        }
    }
}
