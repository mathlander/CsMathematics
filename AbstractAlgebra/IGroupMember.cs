using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra
{
    /// <summary>
    /// Represents the element of an IGroup instance.
    /// </summary>
    internal interface IGroupMember
    {
        /// <summary>
        /// The parent group.
        /// </summary>
        IGroup ParentGroup { get; }

        /// <summary>
        /// The representation of the current IGroupMember instance in terms of its factors.  In the
        /// case that the current instance is a generator of the group, this collection will return just
        /// the current instance.
        /// </summary>
        IEnumerable<IGroupMember> Factors { get; }

        /// <summary>
        /// The inverse to the current IGroupMember with respect to the binary operation of the parent group.
        /// </summary>
        IGroupMember Inverse { get; }
    }
}
