using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entity.HomePage;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Common.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        KhorojiDto<List<HomePageImagesDto>> Execute();
    }

    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IContext _context;
        public GetHomePageImagesService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto<List<HomePageImagesDto>> Execute()
        {
            var images = _context.homePageImsges.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto
                {
                    Id = p.Id,
                    ImageLocation = p.imageLoc,
                    Link = p.Link,
                    Src = p.Src,
                }).ToList();
            return new KhorojiDto<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
            };
        }
    }
    public class HomePageImagesDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLoc ImageLocation { get; set; }
    }
}
