using EndPoint.Site.Utilities;
using Mega.Application.Services.Carts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartServise _cartService;
         private readonly CookiesManeger _cookiesManeger;
        public Cart(ICartServise cartService)
        {
            _cartService = cartService;
             _cookiesManeger = new CookiesManeger();
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(_cookiesManeger.GetBrowzerId(HttpContext),userId).Data);
        }
    }
}
