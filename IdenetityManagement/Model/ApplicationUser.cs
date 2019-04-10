using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenetityManagement.Model
{
    public partial class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [StringLength(256)]
        public string FullName { get; set; }

        public bool IsActive { get; set; }


    }
}

