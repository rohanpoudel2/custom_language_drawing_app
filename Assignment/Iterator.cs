using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// An interface that defines a set of methods for iterating through a collection of objects.
    /// </summary>
    public interface Iterator
    {
        /// <summary>
        /// Determines if there are more items to iterate through.
        /// </summary>
        /// <returns>True if there are more items, false otherwise</returns>
        bool HasNext();

        /// <summary>
        /// Returns the next item in the collection.
        /// </summary>
        /// <returns>The next item in the collection</returns>
        object Next();
    }
}
