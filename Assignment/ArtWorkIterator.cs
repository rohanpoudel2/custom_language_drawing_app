using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// This class represents an iterator for the ArtWork class.
    /// It allows iteration through the shapes in the ArtWork's shape list.
    /// <remarks>
    /// The class implements the Iterator interface, and has two methods: HasNext() and Next().
    /// HasNext() checks if there are more shapes in the list to iterate through and Next() returns the next shape in the list.
    /// </remarks>
    /// </summary>
    public class ArtWorkIterator:Iterator
    {
        /// <summary>
        /// The ArtWork object being iterated over.
        /// </summary>
        private ArtWork artwork;
        /// <summary>
        /// The current index of the iteration.
        /// </summary>
        private int current = 0;

        /// <summary>
        /// Initializes a new instance of the ArtWorkIterator class.
        /// </summary>
        /// <param name="artwork">The ArtWork object to create the iterator for.</param>
        public ArtWorkIterator(ArtWork artwork)
        {
            this.artwork = artwork;
        }

        /// <summary>
        /// Returns a value indicating whether there are more shapes in the list to iterate through.
        /// </summary>
        /// <returns>True if there are more shapes in the list, False otherwise.</returns>
        public bool HasNext()
        {
            return current < artwork.shapes.Count;
        }

        /// <summary>
        /// Returns the next shape in the list.
        /// </summary>
        /// <returns>The next shape in the list, or null if there are no more shapes.</returns>
        public object Next()
        {
            if (HasNext())
            {
                return artwork.shapes[current++];
            }
            else
            {
                return null;
            }
        }
    }
}
