using Mega.Application.Services.Products.Command.AddNewCategory;
using Mega.Application.Services.Products.Command.AddNewProduct;
using Mega.Application.Services.Products.Command.IRemoveCad;
using Mega.Application.Services.Products.Queries.GetAllCategories;
using Mega.Application.Services.Products.Queries.GetCategories;
using Mega.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Mega.Application.Services.Products.Queries.GetProductDetailForSite;
using Mega.Application.Services.Products.Queries.GetProductForAdmin;
using Mega.Application.Services.Products.Queries.GetProductForSite;
using Mega.Application.Services.Users.Command.RemoveProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService  GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
        IRemoveProductService RemoveProductService { get; }
        IRemoveCad RemoveCad { get; }
    }
}
