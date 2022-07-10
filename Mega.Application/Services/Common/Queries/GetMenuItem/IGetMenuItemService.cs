using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        KhorojiDto<List<MenuItemDto>> Execute();   
    }

    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IContext _context;
        public GetMenuItemService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<List<MenuItemDto>> Execute()
        {
            var category = _context.categories
                .Include(p => p.SubCategories)
                .Where(p=> p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CatId = child.Id,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new KhorojiDto<List<MenuItemDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class MenuItemDto
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}
