using Mega.Application.Interface.Context;
using Mega.Application.Services.HomePage.AddNewSlider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IAddNewSlider _addNewSlider;
        private readonly IContext   _context;
        public SliderController(IAddNewSlider addNewSlider, IContext context)
        {
            _addNewSlider = addNewSlider;
            _context = context;
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {


            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file,string Link)
        {
            _addNewSlider.Execute(file, Link); 
            return View();
        }
    }
}
