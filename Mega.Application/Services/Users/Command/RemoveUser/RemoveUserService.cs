using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Linq;

namespace Mega.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IContext _context;

        public RemoveUserService(IContext context)
        {
            _context = context;
        }


        public KhorojiDto Execute(int UserId)
        {
 
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new KhorojiDto
                {
                    IsSuccess = false,
                    Payam = "کاربر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new KhorojiDto()
            {
                IsSuccess = true,
                Payam = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
