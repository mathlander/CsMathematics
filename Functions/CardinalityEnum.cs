using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents the most common options for the size of a set of numbers.
    /// </summary>
    internal enum CardinalityEnum
    {
        /// <summary>
        /// Indicates that a set with this cardinality will have a size equal finite number.
        /// </summary>
        Finite = 0,

        /// <summary>
        /// Indicates that an infinite set has a one-to-one correspondence with the natural numbers.
        /// </summary>
        CountablyInfinite = 1,

        /// <summary>
        /// Indicates that an infinite set has a one-to-one correspondence with the real numbers.
        /// </summary>
        UncountablyInfinite = 2
    }
}
