﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public class CookiesManeger
    {
        public void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public bool Contains(HttpContext context, string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }
        public Guid GetBrowzerId(HttpContext context)
        {
            string browzerId = GetValue(context, "BrowzerId");
            if (browzerId==null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "BrowzerId", value);
                browzerId = value;
            }
            Guid GuidBrowzer;
            Guid.TryParse(browzerId, out GuidBrowzer);
            return GuidBrowzer;
        }

        public string GetValue(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return  cookieValue ;
        }

        public void Remove(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }

 
        private CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(100),
            };
        }
    }
}
