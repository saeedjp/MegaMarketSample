using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entity.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Carts
{
    public interface ICartServise
    {
        //table madoule
        KhorojiDto AddToCart(int ProductId, Guid BrowsId);
        KhorojiDto RemoveCart(int ProductId, Guid BrowsId);
        KhorojiDto<CartDto> GetMyCart(Guid BrowsId, int? UserId);

        KhorojiDto Add(int CartItemId);
        KhorojiDto LowOff(int CartItemId);

    }
    public class CartServise : ICartServise
    {
        private readonly IContext _context;
        public CartServise(IContext context)
        {
            _context = context;
        }


        public KhorojiDto Add(int CartItemId)
        {
            var cartItem = _context.cartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
            };
        }


        public KhorojiDto AddToCart(int ProductId, Guid BrowsId)
        {
            var CART = _context.carts.Where(P => P.BrowseID == BrowsId && P.Finished == false).FirstOrDefault();
            if (CART == null)
            {
                Cart newcart = new Cart()
                {
                    Finished = false,
                    BrowseID = BrowsId,
                };
                _context.carts.Add(newcart);
                _context.SaveChanges();
                CART = newcart;

            }
            var product = _context.pproducts.Find(ProductId);

            var cartItem = _context.cartItems.Where(p => p.ProductId == ProductId && p.cartId == CART.Id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = CART,
                    Count = 1,
                    Price = product.Price,
                    Pproduct = product,

                };
                _context.cartItems.Add(newCartItem);
                _context.SaveChanges();
            }

            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
            };
        }

        public KhorojiDto<CartDto> GetMyCart(Guid BrowsId,int? UserId)
        {

            try
            {
                var cart = _context.carts
                    .Include(p => p.cartItems)
                    .ThenInclude(p => p.Pproduct)
                    .ThenInclude(p => p.ProductImage)
                    .Where(p => p.BrowseID == BrowsId && p.Finished == false)
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault();

                if (cart == null)
                {
                    return new KhorojiDto<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            cartItems = new List<CartItemDto>(),

                        },
                    };
                }

                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.User = user;
                    _context.SaveChanges();
                }

                return new KhorojiDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.cartItems.Count(),
                        SumAmount = cart.cartItems.Sum(p => p.Price * p.Count),
                        CartId = cart.Id,
                        cartItems = cart.cartItems.Select(p => new CartItemDto
                        {
                            Count = p.Count,
                            Price = p.Price,
                            Product = p.Pproduct.Name,
                            Id = p.Id,
                            Images = p.Pproduct?.ProductImage?.FirstOrDefault()?.Src ?? "",
                        }).ToList(),
                    },
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public KhorojiDto LowOff(int CartItemId)
        {
            var cartItem = _context.cartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new KhorojiDto()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
            };
        }

        public KhorojiDto RemoveCart(int ProductId, Guid BrowsId)
        {
            var cartitem = _context.cartItems.Where(p => p.Cart.BrowseID == BrowsId).FirstOrDefault();
            if (cartitem != null)
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new KhorojiDto
                {
                    IsSuccess = true,
                    Payam = "محصول از سبد خرید شما حذف شد"
                };

            }
            else
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "محصول یافت نشد"
                };
            }
        }
    }

    public class CartDto
    {
         public int CartId { get; set; }
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> cartItems { get; set; }
    }
    public class CartItemDto
    {

        public int Id { get; set; }
        public string Images { get; set; }

        public string Product { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }


}
