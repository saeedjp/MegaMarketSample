using Mega.Application.Interfaces.FacadPatterns;
using Mega.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        } 
        public IActionResult Index(Ordering ordering,string searchkey,int page=1,int pagesize=20, int? CatId = null)
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering,searchkey, page, pagesize, CatId).Data);
        }
        public IActionResult Detail(int Id)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
        }
    }
}
 