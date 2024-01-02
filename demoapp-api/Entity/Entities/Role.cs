using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entity.Entities
{
    public class Role : IdentityRole<int>, IBaseEntity
    {

    }
}