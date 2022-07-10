using Mega.Application.Services.Common.Queries.GetHomePageImages;
using Mega.Application.Services.Common.Queries.GetSlider;
using Mega.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.HomePgaeViewModel
{
    public class HomePageViewModel
    {
        public List<SliderDto> sliders { get; set; }
        public List<HomePageImagesDto> homePageImages { get; set; }
        public List<ProductForSiteDto> Kafsh { get; set; }
    }
}
