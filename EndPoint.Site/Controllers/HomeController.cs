using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePgaeViewModel;
using Mega.Application.Interfaces.FacadPatterns;
using Mega.Application.Services.Common.Queries.GetHomePageImages;
using Mega.Application.Services.Common.Queries.GetSlider;
using Mega.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _getHomePageImagesService;
        private readonly IProductFacad _productFacad;


        public HomeController(ILogger<HomeController> logger, IGetSliderService getSliderService, IGetHomePageImagesService getHomePageImagesService, IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _getHomePageImagesService = getHomePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                sliders = _getSliderService.Execute().Data,
                homePageImages=_getHomePageImagesService.Execute().Data,
                Kafsh= _productFacad.GetProductForSiteService.Execute(Ordering.theNewest,null,1,6,22).Data.Products,

            };
            return View(homePage );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
