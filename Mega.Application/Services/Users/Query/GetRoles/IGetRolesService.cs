
using Mega.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        KhorojiDto<List<RolesDto>> Execute();
    }
}
