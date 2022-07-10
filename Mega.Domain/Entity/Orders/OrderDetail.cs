
using Mega.Domain.Entities.Commons;
using Mega.Domain.Entity.Products;

namespace Mega.Domain.Entities.Orders
{
    public class OrderDetail:BaseEntity
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public virtual Pproduct Product { get; set; }
        public int ProductId { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }
    }

}
