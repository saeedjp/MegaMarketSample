using Mega.Application.Services.HomePages.AddHomePageImages;
using Mega.Domain.Entity.HomePage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImageController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;
        public HomePageImageController(IAddHomePageImagesService addHomePageImagesService)
        {
            _addHomePageImagesService = addHomePageImagesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file,string link,ImageLoc imagelocation)
        {
            _addHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                file=file,
                Link=link,
                ImageLocation=imagelocation,
            });

            return View();
        }
    }
}
