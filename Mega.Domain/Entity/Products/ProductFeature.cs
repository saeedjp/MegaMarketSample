using Mega.Domain.Entities.Commons;

namespace Mega.Domain.Entity.Products
{
    public class ProductFeature : BaseEntity
    {
        public virtual Pproduct Product { get; set; }
        public int ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
