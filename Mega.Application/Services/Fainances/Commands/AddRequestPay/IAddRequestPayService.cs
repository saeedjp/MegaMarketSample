using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using Mega.Domain.Entities.Finances;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Fainances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        KhorojiDto<ResultRequestPayDto> Execute(int Amount, int UserId);
    }


    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IContext _context;
        public AddRequestPayService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto<ResultRequestPayDto> Execute(int Amount, int UserId)
        {
            var user = _context.Users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user,

            };
            _context.requestPays.Add(requestPay);
            _context.SaveChanges();

            return new KhorojiDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    guid = requestPay.Guid,
                    Amount=requestPay.Amount,
                    Email=user.Email,
                    RequestPayId=requestPay.Id,
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public int RequestPayId { get; set; }
    }
}
