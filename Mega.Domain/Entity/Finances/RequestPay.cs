using Mega.Domain.Entities.Commons;
using Mega.Domain.Entities.Orders;
using Mega.Domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Domain.Entities.Finances
{
    public class RequestPay:BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }



    }
}
