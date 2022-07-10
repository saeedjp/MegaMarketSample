using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Common.Dto
{
    public class KhorojiDto
    {
        public bool IsSuccess { get; set; }
        public string Payam { get; set; }
       
    }
    public class KhorojiDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Payam { get; set; }
        public T Data { get; set; }
    }
}
