using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CustomCommandNotFoundException: Exception
    {
        public CustomCommandNotFoundException(string message):base(message) { }
    }
}
