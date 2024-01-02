using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entity.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

    }
}