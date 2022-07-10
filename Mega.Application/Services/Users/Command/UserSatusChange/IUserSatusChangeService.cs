using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Commands.UserSatusChange
{
    public interface IUserSatusChangeService
    {
        KhorojiDto Execute(int UserId);
    }

    public class UserSatusChangeService : IUserSatusChangeService
    {
        private readonly IContext _context;


        public UserSatusChangeService(IContext context)
        {
            _context = context;
        }

        public KhorojiDto Execute(int UserId)
        {
            var user = _context.Users.Find( UserId);
            if (user == null)
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }
}
