using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsMathematics.LinearAlgebra;

namespace CsMathematics.Calculus
{
    /// <summary>
    /// Represents a function f: R -&gt; R^n.  Typically, f(t) = \vec{ y }.
    /// </summary>
    public interface IParametricCurve
    {
        /// <summary>
        /// Evaluates the curve at time t = t_i.
        /// </summary>
        /// <param name="t_i">The point in time at which the function is evaluated.</param>
        /// <returns>The value at f(t_i = \vec{ y }_i).</returns>
        IVector Evaluate(double t_i);

        /// <summary>
        /// Defines a new IParametricCurve f' = df/dt.
        /// </summary>
        /// <returns>The derivative of the current IParametricCurve instance f: R -&gt; R^n with respect to the domain variable, t.</returns>
        IParametricCurve DifferentiateWrtTime();
    }
}
