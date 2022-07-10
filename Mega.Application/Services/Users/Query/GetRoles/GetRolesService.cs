using Mega.Application.Interface.Context;
using Mega.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Mega.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IContext _context;

        public GetRolesService(IContext context)
        {
            _context = context;
        }
        public KhorojiDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new KhorojiDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Payam = "",
            };
        }
    }
}
