
using Mega.Domain.Entities.Commons;
using Mega.Domain.Entities.Orders;
using System.Collections.Generic;

namespace Mega.Domain.Entity.Users
{
    public class User : BaseEntity
    {
        //public int Id { get; set; }
        public string Fulname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }

}
