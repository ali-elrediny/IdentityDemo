using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenetityManagement.Model
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string NameAr { get; set; }

        public bool IsActive { get; set; }
    }
}
