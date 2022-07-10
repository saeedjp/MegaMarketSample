using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Linq;

namespace Mega.Application.Services.Users.Command.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IContext _context;
        
        public RemoveProductService(IContext context)
        {
            _context = context;
        }


        public KhorojiDto Execute(int ProductId)
        {
 
            var product = _context.pproducts.Find(ProductId);
            if (product == null)
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "محصول یافت نشد"
                };
            }
            product.RemoveTime = DateTime.Now;
            product.IsRemoved = true;
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "محصول با موفقیت حذف شد"
            };
        }
    }
}
