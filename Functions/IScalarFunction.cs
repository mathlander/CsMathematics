using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsMathematics.Functions
{
    /// <summary>
    /// Represents a function f: R -&gt; R, where f is continuous and differentiable on R.
    /// </summary>
    public interface IScalarFunction : IFunctional
    {
        /// <summary>
        /// Computes the value f(t_i) = y_i.
        /// </summary>
        /// <param name="t_i">The input value t \in R.</param>
        /// <returns>The value y_i, where f(t_i) = y_i.</returns>
        new double Evaluate(double t_i);

        /// <summary>
        /// Computes the new IScalar function f' = df/dt.
        /// </summary>
        /// <returns>The derivative of the current IScalarFunction f: R -&gt; R.</returns>
        new IScalarFunction Differentiate();
    }
}
