using EndPoint.Site.Utilities;
using Mega.Application.Services.Carts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServise _cartServise;
        private readonly CookiesManeger cookiesManeger;

        public CartController(ICartServise cartServise)
        {
            _cartServise = cartServise;
            cookiesManeger = new CookiesManeger();
        }


        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserId(User);

            var resultGetLst = _cartServise.GetMyCart(cookiesManeger.GetBrowzerId(HttpContext), userId);

            return View(resultGetLst.Data);
        }
        //بعد از اینجا با ید ریدایرکت بشه به یجایی
        public IActionResult AddTOCart(int ProductId)
            //gui رو باید از مرور گر کاربر بگیریم

        {
           var resultadd= _cartServise.AddToCart(ProductId, cookiesManeger.GetBrowzerId(HttpContext));

            return RedirectToAction("Index");
        }
        public IActionResult Add(int CartItemId)
        {
            _cartServise.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(int CartItemId)
        {
            _cartServise.LowOff(CartItemId);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int ProductId)
        {
            _cartServise.RemoveCart(ProductId, cookiesManeger.GetBrowzerId(HttpContext));
            return RedirectToAction("Index");

        }
    }
}
