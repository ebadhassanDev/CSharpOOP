using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOOP.Attributes
{
    internal class HttpRoute : Attribute
    {
        public string Name { get; set; }
        public double Version { get; set; }
        public HttpRoute(string route)
        {
            this.Name = route;
            Version = 1.0; 
        }
        public string GetNameOfRoute() => Name; 
    }
}
