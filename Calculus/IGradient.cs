using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.Functions;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// Represents a vector of partial derivatives for a function f: R^n -&gt; R.
    /// </summary>
    public interface IGradient : IVectorOperator, IEnumerable<IFunctional>
    {
    }
}
