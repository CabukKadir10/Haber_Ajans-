﻿using Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string Roles { get; set; }

       // public ICollection<AppRole> Roller { get; set; }
        public ICollection<News> News { get; set; }
    }
}
