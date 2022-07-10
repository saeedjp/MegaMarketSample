using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        KhorojiDto<List<AllCategoriesDto>> Execute();
    }


    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IContext _context;

        public GetAllCategoriesService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
                ).ToList();

            return new KhorojiDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Payam = "",
            };
        }
    }

    public class AllCategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }



}
