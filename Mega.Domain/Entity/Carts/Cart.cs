using Mega.Domain.Entities.Commons;
using Mega.Domain.Entity.Products;
using Mega.Domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Domain.Entity.Carts
{
    public class Cart: BaseEntity
    {
        public virtual User User { get; set; }
        public int? UserId { get; set; }
        public Guid BrowseID { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
    }

    public class CartItem :BaseEntity
    {
        public virtual Pproduct Pproduct { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public virtual Cart Cart { get; set; }
        public  int  cartId { get; set; }


    }
}
