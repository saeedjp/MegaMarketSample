using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entity.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        KhorojiDto<ProductDetailForAdmindto> Execute(int Id);

    }

    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IContext _context;

        public GetProductDetailForAdminService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<ProductDetailForAdmindto> Execute(int Id)
        {
            var product = _context.pproducts
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImage)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            return new KhorojiDto<ProductDetailForAdmindto>()
            {
                Data = new ProductDetailForAdmindto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImage.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                },
                IsSuccess = true,
                Payam = "",
            };
        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }

    public class ProductDetailForAdmindto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public List<ProductDetailFeatureDto> Features { get; set; }
        public List<ProductDetailImagesDto> Images { get; set; }
    }


    public class ProductDetailImagesDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
    }

    public class ProductDetailFeatureDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
