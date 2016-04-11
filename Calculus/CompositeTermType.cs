using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// Specifies what type of differentiable term a CompositeTerm instance defines.
    /// </summary>
    internal enum CompositeTermType
    {
        General = 0,
        Sin = 1,
        Cos = 2,
        Tan = 3,
        Arcsin = 4,
        Arccos = 5,
        Arctan = 6,
        Exp = 7,
        Ln = 8,
    }
}
