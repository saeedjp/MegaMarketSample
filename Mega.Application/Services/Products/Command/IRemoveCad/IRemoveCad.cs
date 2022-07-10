using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Command.IRemoveCad
{
    public interface IRemoveCad
    {
        KhorojiDto Execute(int catId);
    }
    public class RemoveCad : IRemoveCad
    {
        private readonly IContext _context;

        public RemoveCad(IContext context)
        {
            _context = context;
        }


        public KhorojiDto Execute(int catId)
        {

            var CAT = _context.categories.Find(catId);

            if (CAT == null)
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "دسته بندی یافت نشد"
                };
            }
            CAT.RemoveTime = DateTime.Now;
            CAT.IsRemoved = true;
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "دسته بندی با موفقیت حذف شد"
            };
        }
    }

}
