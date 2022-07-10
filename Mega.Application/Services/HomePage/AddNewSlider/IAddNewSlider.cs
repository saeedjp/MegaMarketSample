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

namespace Mega.Application.Services.HomePage.AddNewSlider
{
    public interface IAddNewSlider
    {
        //تصویر رو با IFormFile میگیریم
        KhorojiDto Execute(IFormFile file, string Link);
    }
    public class AddNewSlider : IAddNewSlider
    {
        private readonly IContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewSlider(IContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public KhorojiDto Execute(IFormFile file, string Link)
        {
            var resultUpload = UploadFile(file);


            Slider slider = new Slider()
            {
                Link = Link,
                Src = resultUpload.FileNameAddress,
            };
            _context.sliders.Add(slider);
            _context.SaveChanges();

            return new KhorojiDto()
            {
                IsSuccess = true
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
   

}
