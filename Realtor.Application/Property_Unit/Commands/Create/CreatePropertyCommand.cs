using ErrorOr;
using MediatR;
using Realtor.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Property_Unit.Commands.Create
{
    public record CreatePropertyCommand
    (
         string? Description,
         string? Type,
         string? Address,
         string? Address2,
         string? City,
         string? Region,
         string? PostalCode,
         string? Country,
         string? Phone
    ) : IRequest<ErrorOr<CreatePropertyResult>>;
}
