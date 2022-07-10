using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        KhorojiDto<List<CategoriesDto>> Execute(int? ParentId);
    }

    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IContext _context;

        public GetCategoriesService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<List<CategoriesDto>> Execute(int? ParentId)
        {
            var categories = _context.categories
               .Include(p => p.ParentCategory)
               .Include(p => p.SubCategories)
               .Where(p => p.ParentCategoryId == ParentId)
               .ToList()
               .Select(p => new CategoriesDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Parent = p.ParentCategory != null ? new
                   ParentCategoryDto
                   {
                       Id = p.ParentCategory.Id,
                       name = p.ParentCategory.Name,
                   }
                   : null,
                   HasChild = p.SubCategories.Count() > 0 ? true : false,
               }).ToList();


            return new KhorojiDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Payam = "لیست باموقیت برگشت داده شد"
            };

        }
    }
    public class CategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    }
    public class ParentCategoryDto
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}



