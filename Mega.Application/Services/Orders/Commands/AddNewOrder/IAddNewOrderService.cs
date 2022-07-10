using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        KhorojiDto Execute(RequestAddNewOrderSericeDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IContext _context;
        public AddNewOrderService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto Execute(RequestAddNewOrderSericeDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.requestPays.Find(request.RequestPayId);
            var cart = _context.carts.Include(p => p.cartItems)
                .ThenInclude(p=> p.Pproduct)
                .Where(p => p.Id == request.CartId).FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = request.RefId;
            requestPay.Authority = requestPay.Authority;
            cart.Finished = true;

            Order order = new Order()
            {
                Address = "",
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,

            };
            _context.orders.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.cartItems)
            {

                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Pproduct.Price,
                    Product = item.Pproduct,
                };
                orderDetails.Add(orderDetail);
            }


            _context.orderDetails.AddRange(orderDetails);

            _context.SaveChanges();

            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "",
            };
        }
    }
    public class RequestAddNewOrderSericeDto
    {
        public int   CartId { get; set; }
        public int   RequestPayId { get; set; }
        public int UserId { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;

    }
}
