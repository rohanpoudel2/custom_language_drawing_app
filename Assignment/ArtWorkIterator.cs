using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ArtWorkIterator:Iterator
    {
        private ArtWork artwork;
        private int current = 0;

        public ArtWorkIterator(ArtWork artwork)
        {
            this.artwork = artwork;
        }

        public bool HasNext()
        {
            return current < artwork.shapes.Count;
        }

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
