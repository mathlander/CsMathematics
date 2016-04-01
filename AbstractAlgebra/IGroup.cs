using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra
{
    /// <summary>
    /// Represents the concept of a group.  A set G together with a binary operation \circ
    /// are known as a group, if:
    ///     1. for any two elements a, b \in G, the result of the binary operation a \circ b = c \in G;
    ///     2. additionally, there exists e \in G, such that for all a \in G, a \circ e = e \circ a = a; and
    ///     3. finally, for all g \in G, there exists g^{-1} \in G, such that g \circ g^{-1} = g^{-1} \circ g = e.
    /// </summary>
    internal interface IGroup
    {
        IBinaryOperation BinaryOperation { get; }
        IGroupMember Identity { get; }
        IEnumerable<IGroupMember> Members { get; }
    }
}
