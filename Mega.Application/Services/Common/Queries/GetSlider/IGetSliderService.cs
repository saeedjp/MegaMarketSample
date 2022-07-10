using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        KhorojiDto<List<SliderDto>> Execute();
    }

    public class GetSliderService : IGetSliderService
    {
        private readonly IContext _context;
        public GetSliderService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto<List<SliderDto>> Execute()
        {
            var sliders = _context.sliders.OrderByDescending(p => p.Id).ToList().Select(
                p => new SliderDto
                {
                    Link=p.Link,
                    Src=p.Src,
                }).ToList();

            return new KhorojiDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };
        }
    }

    public   class SliderDto
    {
        public string   Src { get; set; }
        public string   Link { get; set; }
    }
}
