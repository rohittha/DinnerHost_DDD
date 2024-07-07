using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Realtor.Domain.Common.Errors.Errors;

namespace Realtor.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;


        private User(
            string firstName,
            string lastName,
            string email,
            string password)
            //DateTime createdDateTime,
            //DateTime updatedDateTime)
            //: base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            //CreatedDateTime = createdDateTime;
            //UpdatedDateTime = updatedDateTime;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new(                
                firstName,
                lastName,
                email,
                password);
                //DateTime.UtcNow,
                //DateTime.UtcNow);
        }
    }
}
