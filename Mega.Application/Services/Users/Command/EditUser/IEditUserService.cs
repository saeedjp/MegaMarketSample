using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        KhorojiDto Execute(RequestEdituserDto request);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IContext _context;

        public EditUserService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "کاربر یافت نشد"
                };
            }

            user.Fulname = request.Fullname;
            user.Email = request.Email;
            _context.SaveChanges();

            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "ویرایش کاربر انجام شد"
            };

        }
    }


    public class RequestEdituserDto
    {
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
}
