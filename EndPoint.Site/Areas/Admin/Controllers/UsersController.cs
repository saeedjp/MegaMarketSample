using Mega.Application.Services.Users.Command.SabteNam;
using Mega.Application.Services.Users.Commands.EditUser;
using Mega.Application.Services.Users.Commands.RemoveUser;
using Mega.Application.Services.Users.Commands.UserSatusChange;
using Mega.Application.Services.Users.Queries.GetRoles;
using Mega.Application.Services.Users.Query.GetUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IGetuserService _getuserService;
        private readonly IGetRolesService _getRolesService;
        private readonly ISabteNam _sabteNam;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;

        public UsersController(IGetuserService getuserService, IGetRolesService getRolesService, ISabteNam sabteNam, IRemoveUserService removeUserService, IUserSatusChangeService userSatusChangeService, IEditUserService editUserService)
        {
            _getuserService = getuserService;
            _getRolesService = getRolesService;
            _sabteNam = sabteNam;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }
        public IActionResult Index( string serchkey, int page = 1)
       {
            return View(_getuserService.Execute(new RequesttDto
            {
                Page = page,
                serchkey = serchkey,


            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Fullname, string Email, int RoleId, string Password, string RePassword)
        {
            var result = _sabteNam.Execute(new VorodiSabteNamDto
            {
                Email = Email,
                Fullname = Fullname,
                Naghsh = new List<NaghshKarbarSabteNam>()
                {
                    new NaghshKarbarSabteNam
                    {
                        IdNaghsh=RoleId
                    }
                },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(int UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult UserSatusChange(int UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }
        [HttpPost]
        public IActionResult Edit(int UserId, string Fullname,string Email)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
                Email=Email,
            }));
        }


    }
}
