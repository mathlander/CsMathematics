using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.AbstractAlgebra.NumberFields
{
    /// <summary>
    /// Represents the concept of a field.  That is, a set F which is a commutative group
    /// with respect to two compatible operations, + and \circ.
    /// </summary>
    interface IField
    {
        IBinaryOperation AdditiveOperator { get; }
        IBinaryOperation MultiplicativeOperator { get; }

        IFieldMember Add(IFieldMember member);
        IFieldMember Multiply(IFieldMember member);
    }
}
