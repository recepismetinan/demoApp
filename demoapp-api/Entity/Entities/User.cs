using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entity.Entities
{
    public class User : IdentityUser, IBaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }

    }
}