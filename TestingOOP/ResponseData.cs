using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOOP
{
    public class ResponseData
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public IEnumerable<string> Data { get; set; }
    }
}
