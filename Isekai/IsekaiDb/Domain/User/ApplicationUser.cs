﻿using IsekaiDb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsekaiDb.Domain.User
{
    public class ApplicationUser : IdentityUser
    {
        List<Character> Characters { get; set; }
    }
}
