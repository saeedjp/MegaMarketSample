using Mega.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        KhorojiDto Execute(int UserId);
    }
}
