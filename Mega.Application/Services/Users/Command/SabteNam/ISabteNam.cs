using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mega.Domain.Entity.Users;
using Mega.Common;

namespace Mega.Application.Services.Users.Command.SabteNam
{
    public interface ISabteNam
    {
        KhorojiDto<KhorojieSabteNamDto> Execute(VorodiSabteNamDto Request);
    }



    public class SabteNam : ISabteNam
    {
        private readonly IContext _context;
        public SabteNam(IContext context)
        {
            _context = context;
        }

        public KhorojiDto<KhorojieSabteNamDto> Execute(VorodiSabteNamDto Request)
        {
            try
            {
                //ولیدیشن فیلد ها رو انجام میدیم 
                if (string.IsNullOrWhiteSpace(Request.Email))
                {
                    return new KhorojiDto<KhorojieSabteNamDto>()
                    {
                        Data = new KhorojieSabteNamDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Payam = "پست الکترونیک را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(Request.Fullname))
                {
                    return new KhorojiDto<KhorojieSabteNamDto>()
                    {
                        Data = new KhorojieSabteNamDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Payam = "نام را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(Request.Password))
                {
                    return new KhorojiDto<KhorojieSabteNamDto>()
                    {
                        Data = new KhorojieSabteNamDto()
                        {

                            UserId = 0,
                        },
                        IsSuccess = false,
                        Payam = "پسورد را وارد کنید"
                    };
                }
                if (Request.Password != Request.RePasword)
                {
                    return new KhorojiDto<KhorojieSabteNamDto>()
                    {
                        Data = new KhorojieSabteNamDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Payam = "رمز عبور و تکرار آن برابر نیست"
                    };
                }
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(Request.Password);

                User user = new User()
                {
                    Email = Request.Email,
                    Fulname = Request.Fullname,
                    Password = hashedPassword,
                    IsActive = true,

                    /*     HashPassword.Execute(Request.Password),*/

                };
                List<UserInRole> userInRoles = new List<UserInRole>();

                foreach (var item in Request.Naghsh)
                {
                    var roles = _context.Roles.Find(item.IdNaghsh);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        User = user,
                        UserId = user.Id,
                        RoleId = roles.Id,
                    });
                }
                user.UserInRole = userInRoles;
                _context.Users.Add(user);
                _context.SaveChanges();

                return new KhorojiDto<KhorojieSabteNamDto>()
                {
                    Data = new KhorojieSabteNamDto()
                    {
                        UserId = user.Id,
                    },

                    IsSuccess = true,

                    Payam = "ثبت نام کاربر انجام شد",

                };
            }
            catch (Exception)
            {

                return new KhorojiDto<KhorojieSabteNamDto>()
                {
                    Data = new KhorojieSabteNamDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Payam = "ثبت نام انجام نشد !"
                };

            }






        }
    }
    public class KhorojieSabteNamDto
    {
        public int UserId { get; set; }

    }
    public class NaghshKarbarSabteNam
    {
        public int IdNaghsh { get; set; }
    }
    public class VorodiSabteNamDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public List<NaghshKarbarSabteNam> Naghsh { get; set; }
    }
}
