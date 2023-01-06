using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CustomConditionException:Exception
    {
        public CustomConditionException(string message) : base(message) { }

        public string Message
        {
            get {return base.Message; }
        }
    }
}
