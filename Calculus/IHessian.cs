using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// Represents a matrix of mixed second order partial derivatives taken from a function f: R^n -&gt; R.
    /// </summary>
    public interface IHessian : IJacobian
    {
    }
}
