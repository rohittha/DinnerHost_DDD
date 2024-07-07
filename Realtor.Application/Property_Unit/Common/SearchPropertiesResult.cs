﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Property_Unit.Common
{
    public record SearchPropertiesResult
    (
         int Id 
        , string? Description 
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