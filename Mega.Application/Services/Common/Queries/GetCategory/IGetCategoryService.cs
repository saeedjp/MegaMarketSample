using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        KhorojiDto<List<CategoryDto>> Execute();
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IContext _context;
        public GetCategoryService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto<List<CategoryDto>> Execute()
        {

            var category = _context.categories.Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto
                {
                    CatId = p.Id,
                    CategoryName = p.Name,
                }).ToList();

            return new KhorojiDto<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class CategoryDto
    {
        public int CatId { get; set; }
        public string CategoryName { get; set; }
    }
}
