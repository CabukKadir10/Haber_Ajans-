﻿using Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppRole : IdentityRole<int>, IEntity
    {
       // public ICollection<AppUser> Users { get; set; } 
    }
}
