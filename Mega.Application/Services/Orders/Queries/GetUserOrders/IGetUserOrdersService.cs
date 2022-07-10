using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Orders.Queries.GetUserOrders
{
    public interface IGetUserOrdersService
    {
        KhorojiDto<List<GetUserOrdersDto>> Execute(int UserId);
    }


    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IContext _context;

        public GetUserOrdersService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<List<GetUserOrdersDto>> Execute(int UserId)
        {
            var orders = _context.orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToList().Select(p => new GetUserOrdersDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailsDto
                    {
                        Count = o.Count,
                        OrderDetailId = o.Id,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,
                    }).ToList(),
                }).ToList();

            return new KhorojiDto<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };


        }
    }

    public class GetUserOrdersDto
    {
        public int OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public int RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
