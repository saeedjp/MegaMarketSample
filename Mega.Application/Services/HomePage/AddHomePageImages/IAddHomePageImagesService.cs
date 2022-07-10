using Mega.Application.Interface.Context;
using Mega.Application.Services.Products.Command.AddNewProduct;
using Mega.Common.Dto;
using Mega.Domain.Entity.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.HomePages.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        KhorojiDto Execute(requestAddHomePageImagesDto request);
    }


    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IContext _context;
        private readonly IHostingEnvironment _environment;

        public AddHomePageImagesService(IContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _environment = hosting;
        }
        public KhorojiDto Execute(requestAddHomePageImagesDto request)
        {

            var resultUpload = UploadFile(request.file);

            HomePageImsges homePageImages = new HomePageImsges()
            {
                Link = request.Link,
                Src = resultUpload.FileNameAddress,
                imageLoc = request.ImageLocation,
            };
            _context.homePageImsges.Add(homePageImages);
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
            };
        }




        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class requestAddHomePageImagesDto
    {
        public IFormFile      file { get; set; }
        public string Link { get; set; }
        public ImageLoc ImageLocation{ get; set; }
    }
}
