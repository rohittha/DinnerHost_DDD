﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Common;

namespace Realtor.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse: IErrorOr
    {
        public readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator =null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if(_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);  
            if(validationResult.IsValid) {
                return await next();
            }

            var errors = validationResult.Errors
                .Select(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage))
                .ToList();
           
            //var result = await next();
            return (dynamic)errors;
        }
    }
}
