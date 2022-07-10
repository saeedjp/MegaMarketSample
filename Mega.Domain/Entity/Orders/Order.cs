using Mega.Domain.Entities.Commons;
using Mega.Domain.Entities.Finances;
using Mega.Domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual RequestPay RequestPay { get; set; }
        public int RequestPayId { get; set; }

        public OrderState OrderState { get; set; }

        public string Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
     }

}
