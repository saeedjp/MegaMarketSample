using Mega.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
        public class GetMenueResponse: ViewComponent
        {
            private readonly IGetMenuItemService _getMenuItemService;
            public GetMenueResponse(IGetMenuItemService getMenuItemService)
            {
                _getMenuItemService = getMenuItemService;
            }


            public IViewComponentResult Invoke()
            {
                var menuItem = _getMenuItemService.Execute();
                return View(viewName: "GetMenueResponse", menuItem.Data);
            }

        }
}
