using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DAL.Model
{
    public class IdentityUser : EntityBase
    {
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string PhoneNumber { get; set; }

        
        //roles     
    }
}
