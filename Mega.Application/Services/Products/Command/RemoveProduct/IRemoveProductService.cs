using Mega.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Users.Command.RemoveProduct
{
    public interface IRemoveProductService
    {
        KhorojiDto Execute(int ProductId);
    }
}
