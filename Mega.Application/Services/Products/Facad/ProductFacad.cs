using Mega.Application.Interface.Context;
using Mega.Application.Interfaces.FacadPatterns;
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
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacad(IContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }    
        
        
        private IGetCategoriesService  _getCategoriesService;
        public IGetCategoriesService  GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private AddNewProductService _addNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }
        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }
        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }
        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }
        private IRemoveProductService _removeProductService;
        public IRemoveProductService RemoveProductService
        {
            get
            {
                return _removeProductService = _removeProductService ?? new RemoveProductService(_context);
            }
        }
        private IRemoveCad _removeCad;
        public IRemoveCad RemoveCad
        {
            get
            {
                return _removeCad = _removeCad ?? new RemoveCad(_context);
            }
        }
    }
    
}
