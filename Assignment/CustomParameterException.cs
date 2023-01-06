using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CustomParameterException:Exception
    {
        public CustomParameterException(string message) : base(message) { }
    }
}
