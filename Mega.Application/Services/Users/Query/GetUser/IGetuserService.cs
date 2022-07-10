using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Query.GetUser
{
    public interface IGetuserService
    {
        ResultGetUserDto Execute(RequesttDto Request);
    }
}
