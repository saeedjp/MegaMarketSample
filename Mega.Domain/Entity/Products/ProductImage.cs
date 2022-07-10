using Mega.Domain.Entities.Commons;

namespace Mega.Domain.Entity.Products
{
    public class ProductImage : BaseEntity
    {
        public virtual Pproduct Product { get; set; }
        public int ProductId { get; set; }
        public string Src { get; set; }
    }
}
