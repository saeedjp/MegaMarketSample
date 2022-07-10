using System.Collections.Generic;

namespace Mega.Application.Services.Users.Query.GetUser
{
    public class ResultGetUserDto
    {
        public List<GetUserDto> users { get; set; }
        public int  Rows { get; set; }
    }
}
