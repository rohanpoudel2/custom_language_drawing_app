using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Custom exception class used to handle exceptional cases in the application
    /// </summary>
    public class CustomConditionException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomConditionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomConditionException(string message) : base(message) { }

        /// <summary>
        /// Gets the message that describes the error.
        /// </summary>
        public string Message
        {
            get {return base.Message; }
        }
    }
}
