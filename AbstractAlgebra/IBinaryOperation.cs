using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra
{
    internal interface IBinaryOperation
    {
        /// <summary>
        /// Indicates whether or not the binary operation allows commutativity of
        /// the elements.  True if (\forall g \in G)  a \circ b = b \circ a.
        /// </summary>
        bool IsAbelian { get; }

        /// <summary>
        /// Indicates whether or not the binary operation allows for associativity.
        /// True if (a \circ b) \circ c = a \circ (b \circ c).
        /// </summary>
        bool IsAssociative { get; }

        /// <summary>
        /// This method performs the binary operation which acts on a group.
        /// </summary>
        /// <param name="a">The left element in the binary operation.</param>
        /// <param name="b">The right element in the binary operation.</param>
        /// <returns>Where a \circ b = c, this method returns c.</returns>
        //IGroupMember Operate(IGroupMember a, IGroupMember b);
    }
}
