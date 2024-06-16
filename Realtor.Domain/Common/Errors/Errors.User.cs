﻿using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail
            {
                get
                {
                    return Error.Conflict(
                        code: "User.DuplicateEmail",
                        description: "Email is already in use.");
                }
            }
        }
    }
}
