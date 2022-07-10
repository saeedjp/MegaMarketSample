using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Command.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        KhorojiDto Execute(int? ParentId, string Name);
    }

    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IContext _context;
        public AddNewCategoryService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto Execute(int? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new KhorojiDto()
                {
                    IsSuccess = false,
                    Payam = "نام دسته بندی را وارد نمایید",
                };
            }

            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId)
            };
            _context.categories.Add(category);
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "دسته بندی با موفقیت اضافه شد",
            };
        }

        private Category GetParent(int? ParentId)
        {
            return _context.categories.Find(ParentId);
        }
    }
}
