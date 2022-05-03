
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MyUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoURL { get; set; }
        public string About { get; set; }

    }
}
