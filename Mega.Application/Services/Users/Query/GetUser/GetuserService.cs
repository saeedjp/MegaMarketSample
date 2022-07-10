using Bugeto_Store.Common;
using Mega.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mega.Application.Services.Users.Query.GetUser
{
    public class GetuserService : IGetuserService
    {
        private readonly IContext _context;
        public GetuserService(IContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequesttDto Request)
        {
            //باید کوِری بزنیم 
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(Request.serchkey))
            {
                users = users.Where(p => p.Fulname.Contains(Request.serchkey) && p.Email.Contains(Request.serchkey));
            }
            int rowscount = 0;
            var  Userlist= users.ToPaged(Request.Page, 20, out rowscount).Select(p => new GetUserDto     //عملیات مپ کردن
            {
                Id = p.Id,
                Email = p.Email,
                Fulname = p.Fulname,
                IsActive = p.IsActive




            }).ToList();
            return new ResultGetUserDto
            {
                users = Userlist,
                Rows = rowscount,
            };
        }

      
    }
}
